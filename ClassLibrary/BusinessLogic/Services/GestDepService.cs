using GestDep.Entities;
using GestDep.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestDep.Services
{
    public class GestDepService : IGestDepService
    {
        private readonly IDAL dal; //Persistence Layer Interface
        public CityHall cityHall;  //Services only work on a City Hall
        public Gym gym;			   // Gym of the City Hall. Also available from cityHall.Gyms.First();

        
        /// </summary>
        /// Returns a service Layer connected with the persistence Layer. Retrieves the CitiHall and Gym from the database if they exist. If not, it creates new ones
        /// </summary>
        /// <param name="dal"> Persistence Layer Interface</param>
        
        public GestDepService(IDAL dal)
        {
            this.dal = dal;
            try
            {
                    
                if (dal.GetAll<CityHall>().Count() == 0) //No cityHall in the system. Data initilization. 
                {
                    bool CLEAR_DATABASE = true;
                    int ROOMS_NUMBER = 9;
                    int INSTRUCTORS_NUMBER = 5;
                    Populate populateDB = new Populate(CLEAR_DATABASE,dal);
                    cityHall = populateDB.InsertCityHall();
                    gym = populateDB.InsertGym(cityHall);     //Also in cityHall.First();                
                    populateDB.InsertRooms(ROOMS_NUMBER, gym);  //Now available from gym.rooms;
                    populateDB.InsertInstructors(INSTRUCTORS_NUMBER, cityHall); //Now available from cityHall.People;

                }
                else
                {   //Retrieve the CityHall stored
                    cityHall = dal.GetAll<CityHall>().First();

                    if (cityHall.Gyms.Count > 0)
                    { //Retrieve the Gym stored
                        gym = cityHall.Gyms.First();
                    }
                    else
                    { //Adding Rooms and Gym
                        bool MANTAIN_DATABASE = false;
                        int ROOMS_NUMBER = 9;
                        Populate populateDB = new Populate(MANTAIN_DATABASE, dal);
                        gym = populateDB.InsertGym(cityHall);
                        populateDB.InsertRooms(ROOMS_NUMBER, gym);
                    }
                    int INSTRUCTORS_NUMBER = 5;
                    if (dal.GetAll<Instructor>().Count() == 0)//No instructors
                    { 
                        bool MANTAIN_DATABASE = false;
                        Populate populateDB = new Populate(MANTAIN_DATABASE, dal);
                        populateDB.InsertInstructors(INSTRUCTORS_NUMBER, cityHall); //Now available from cityHall.People;
                    }

                }
            } catch(Exception e)
            {
                throw new ServiceException("Error in the service init process", e);
                
            }
        }
        //Añadir actividad

        public int AddNewActivity(Days activityDays, string description, TimeSpan duration, DateTime finishDate, int maximumEnrollments, int minimumEnrollments, double price, DateTime startDate, DateTime startHour, ICollection<int> roomsIds)
        {
            if(roomsIds != null && roomsIds.Count() > 0){
                List<int> salasIdsInsertar = roomsIds.ToList();
                List<Room> salasGym = gym.Rooms.ToList();
                bool exist = existe(salasIdsInsertar, salasGym);

                if (!exist) { throw new ServiceException("Ids de salas no existentes"); }

                if (duration.TotalSeconds > 0 && activityDays != Days.None) {
                    if (maximumEnrollments >= 0 && minimumEnrollments >= 0 && minimumEnrollments <= maximumEnrollments && price >= 0 ) { 
                        if (startDate >= DateTime.Now && startDate < finishDate) {
                            List<Activity> actividades = gym.Activities.ToList();
                            Activity insertar = new Activity(activityDays, description, duration, finishDate, maximumEnrollments, minimumEnrollments, price, startDate, startHour);
                            foreach (Activity actividad in actividades) {
                                List<Room> salasActividad = actividad.Rooms.ToList(); //salas de la actividad que estoy inspeccionando
                                foreach (Room room in salasActividad) {
                                    foreach (int id in salasIdsInsertar) {
                                        if (room.Id == id) {
                                            if ((!(finishDate <= actividad.StartDate) && (finishDate >= actividad.FinishDate)) || (!(actividad.FinishDate <= startDate) && (actividad.FinishDate >= finishDate))) {
                                                List<String> aux = calculaDias(activityDays);
                                                List<String> aux2 = calculaDias(actividad.ActivityDays);
                                                foreach (String dia in aux) {
                                                    foreach (String dia2 in aux2) {
                                                        if (dia == dia2 && !inRange(new DateTime(startDate.Year, startDate.Month, startDate.Day, startHour.Hour, startHour.Minute, startHour.Second), duration, new DateTime(startDate.Year, startDate.Month, startDate.Day, actividad.StartHour.Hour, actividad.StartHour.Minute, actividad.StartHour.Second), actividad.Duration)) {
                                                            //Coinciden en 1 dia y ademas se solapan en el tiempo -- EXCEPCION LA ACTIVIDAD NO SE PUEDE CREAR
                                                            throw new ServiceException("Actividad");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            ICollection<Room> agregar = gym.Rooms.Where(a => roomsIds.Contains(a.Id)).Select(a => a).ToList();
                            insertar.Rooms = agregar;
                            foreach (Room sala in agregar) {
                                sala.Activities.Add(insertar);
                            }
                            gym.Activities.Add(insertar);
                            SaveChanges();
                            return insertar.Id;
                        }
                        else throw new ServiceException("Start date is before actual date or finish date is before start date");
                    }
                    else throw new ServiceException("MaximumEnrollments negative or MinimumEnrollments negative or MinumumnEnrollments > MaximumEnrollemnts or price is negative");
                }
                else throw new ServiceException("Duration value is 0 o Days = NONE");
            }
            else throw new ServiceException("Lista vacía");    
        }

        public List<String> calculaDias(Days days) {
            List<String> aux = new List<String>();
            if (days.HasFlag(Days.Mon)){
                aux.Add("Monday");
            }
            if (days.HasFlag(Days.Tue))
            {
                aux.Add("Tuesday");
            }
            if (days.HasFlag(Days.Wed))
            {
                aux.Add("Wednesday");
            }
            if (days.HasFlag(Days.Thu))
            {
                aux.Add("Thursday");
            }
            if (days.HasFlag(Days.Fri))
            {
                aux.Add("Friday");
            }
            if (days.HasFlag(Days.Sat))
            {
                aux.Add("Saturday");
            }
            if (days.HasFlag(Days.Sun))
            {
                aux.Add("Sunday");
            }
            if (days.HasFlag(Days.None))
            {
                aux.Add("None");
            }
            return aux;
        }

        public bool existe(List<int> salasIdsInsertar, List<Room> salasGym) {

            List<int> idSalasActividades = new List<int>();
            foreach (Room room in salasGym){
                idSalasActividades.Add(room.Id);
            }

            foreach (int id in salasIdsInsertar) {
                if (!idSalasActividades.Contains(id)) return false;
            }
            return true;
        }

        public void AddNewUser(string address, string iban, string id, string name, int zipCode, DateTime birthDate, bool retired)
        {
            
            Regex DNI = new Regex("^([0-9]){8}([A-Z]){1}$");


            if (zipCode > 0 && name.Length > 0 && id != null && id.Length>0 && DNI.IsMatch(id) && iban.Length>0 && address.Length>0)
            {           
                if (birthDate < DateTime.Now)
                {

                    bool exists = cityHall.People.Where(p => p.Id == id).Count() > 0;
                    if (!exists)
                    {
                        cityHall.People.Add(new User(address,iban,id,name,zipCode,birthDate,retired));
                        SaveChanges();
                    }
                    else
                    {
                        throw new ServiceException("The current user alredy exists");
                    }
                }
                else
                {
                    throw new ServiceException("The birthdate can't be higher than current date");
                }
            }
            else 
            {
                throw new ServiceException("The user data is not valid");
            }
        }
        //Añadir monitor a una actividad
        public void AssignInstructorToActivity(int activityId, string instructorId)
        {
            //que dada un actividad haya un instructor que imparta otra actividad que se haga en el mismo lapso de tiempo
            bool valor = true;
            Activity[] listaActividades = gym.Activities.ToArray();

            Instructor instructor = cityHall.getInstructorById(instructorId);
            if (instructor == null) throw new ServiceException("Can't find instructor");
            if (activityId < 0) throw new ServiceException("Id can not be negative number");

            for (int i = 0; i < listaActividades.Length; i++)
            {

                Activity actividad = listaActividades[i];
                if (actividad.Id == activityId)
                {

                    valor = false;
                    foreach (Activity act2 in instructor.Activities)
                    {

                        if (!inRange(actividad.StartHour, actividad.Duration, act2.StartHour, act2.Duration))
                        {

                            throw new ServiceException("Se encontro Actividad y Monitor dado, pero monitor ya imparte otra actividad en el mismo lapso de tiempo");

                        }
                    }

                    instructor.Activities.Add(actividad);
                    actividad.Instructor = instructor;
                }
            }

            if (valor) throw new ServiceException("No se ha encontrado la actividad dada");
        }

          

        public int EnrollUserInActivity(int activityId, string userId)
        {
            Activity activity = gym.getActivityById(activityId);
            User user = cityHall.getUserById(userId);

            if (activity == null) // Checks if the activity exists
            {
                throw new ServiceException("ERROR: The activity does not exist");
            }

            if (user == null) // Checks if the user exists
            {
                throw new ServiceException("ERROR: The user does not exist");
            }

            if (activityId <= 0) // Checks if the activityId is negative
            {
                throw new ServiceException("ERROR: The ID of the activity is invalid");
            }

            if (userId == null) // Checks if the userId is empty
            {
                throw new ServiceException("ERROR: The ID of the activity is invalid");
            }

            if (activity.userAlreadySignedUp(user)) // Checks if the userId is signed up to any activity
            {
                throw new ServiceException("ERROR: The user is already signed up to an activity");
            }

            double quota = activity.calculateQuota(user, gym.DiscountLocal, gym.DiscountRetired, gym.ZipCode);

            string description = "Enrollment";
            DateTime enrollmentDate = DateTime.Now;

            Payment payment = new Payment(enrollmentDate, description, quota); // Final payment
            Enrollment enrollment = new Enrollment(enrollmentDate, activity, payment, user); // Final enrollment

            user.Enrollments.Add(enrollment);
            activity.Enrollments.Add(enrollment);
            cityHall.Payments.Add(payment);
            SaveChanges();

            return enrollment.Id;
        }

        public void GetActivityDataFromId(int ActivityId, out Days activityDays, out string description, out TimeSpan duration, out DateTime finishDate, out int maximumEnrollments, out int minimumEnrollments, out double price, out DateTime startDate, out DateTime startHour, out ICollection<int> enrollmentIds, out string instructorId, out ICollection<int> roomIds)
        {
            var listaActividades = gym.Activities.ToArray();
            activityDays = Days.None;
            description = "";
            duration = new TimeSpan();
            finishDate = new DateTime();
            maximumEnrollments = 0;
            minimumEnrollments = 0;
            price = 0.00;
            startDate = new DateTime();
            startHour = new DateTime();
            enrollmentIds = new List<int>();
            instructorId = "";
            roomIds = new List<int>();
            bool valor = true;

            for (int i = 0; i < listaActividades.Length; i++)
            {
                if (listaActividades[i].Id == ActivityId)
                {
                    valor = false;
                    Activity actividad = listaActividades[i];

                    activityDays = actividad.ActivityDays;
                    description = actividad.Description;
                    duration = actividad.Duration;
                    finishDate = actividad.FinishDate;
                    maximumEnrollments = actividad.MaximumEnrollments;
                    minimumEnrollments = actividad.MinimumEnrollments;
                    price = actividad.Price;
                    startDate = actividad.StartDate;
                    startHour = actividad.StartHour;

                    if (actividad.Enrollments.Count() > 0) //si tiene algun inscrito devuelvo enrollmentsIds relleno
                    {
                        foreach (Enrollment enrol in actividad.Enrollments)
                        {
                            enrollmentIds.Add(enrol.Id);

                        }
                    }

                    if (actividad.Instructor.Name.ToString().Equals(null))
                    { // como su nombre es null, el instructor no ha sido asignado, por lo que devulevo cadena vacia

                    }
                    else
                    { //si tiene insctructor, devuelvo su id en un string

                        instructorId = actividad.Instructor.Id.ToString();
                    }

                    if (actividad.Rooms.Count() > 0)  //si hay alguna room asignada, la meto en la lista
                    {
                        foreach (Room room in actividad.Rooms)
                        {
                            roomIds.Add(room.Id);
                        }
                    }


                }
            }

            if (valor) throw new ServiceException(); //no ha encontrado la actividad, devuelvo excepcion

        }

        public ICollection<int> GetAllActivitiesIds()
        {
            ICollection<int> devolver = new List<int>();
            Activity[] listaActividades = gym.Activities.ToArray();

            for (int i = 0; i < listaActividades.Length; i++)
            {
                devolver.Add(listaActividades[i].Id);
            }

            return devolver;
        }


        public ICollection<int> GetAllRunningOrFutureActivitiesIds()
        {
            ICollection<int> activityIds = gym.getIdFromFutureActivity();

            if (activityIds == null) // Checks if there are no activities
            {
                throw new ServiceException("ERROR: There are no activities");
            }

            return activityIds;
        }

        public ICollection<string> GetAvailableInstructorsIds(Days activityDays, TimeSpan duration, DateTime finishDate, DateTime startDate, DateTime startHour)
        {
            ICollection<Instructor> listaInstructores = cityHall.getAllInstructors();
            ICollection<string> availableIns = new List<string>();

            if (activityDays != Days.None && duration.TotalSeconds > 0 && finishDate > startDate && startDate > DateTime.Now && finishDate > DateTime.Now)
            {
                foreach (Instructor ins in listaInstructores)
                {

                    bool available = true;
                    ICollection<Activity> actividades = ins.Activities;

                    foreach (Activity act in actividades)
                    {
                        if (!inRange(act.StartHour, act.Duration, startHour, duration))
                        {

                            available = false;

                        }
                    }
                    if (available) { availableIns.Add(ins.Id); }
                }
                return availableIns;
            }
            else throw new ServiceException();

        }


        public void GetEnrollmentDataFromIds(int activityId, int enrollmentId, out DateTime? cancellationDate, out DateTime enrollmentDate, out DateTime? returnedFirstCuotaIfCancelledActivity, out ICollection<int> paymentIds, out string userId)
        {
            if (activityId < 0) // Checks if the activityId is negative
            {
                throw new ServiceException("ERROR: The ID of the activity is invalid");
            }

            if (enrollmentId < 0) // Checks if the enrollmentId is negative
            {
                throw new ServiceException("ERROR: The ID of the enrollment is invalid");
            }

            Activity activity = gym.getActivityById(activityId);
           

            if (activity == null) // Checks if the activity exists
            {
                throw new ServiceException("ERROR: The activity does not exist");
            }
            Enrollment enrollment = activity.getEnrollmentById(enrollmentId);

            if (enrollment == null) // Checks if the enrollment exists
            {
                throw new ServiceException("ERROR: The enrollment does not exist");
            }

            Payment[] allIds = cityHall.Payments.ToArray();
            cancellationDate = enrollment.CancellationDate;
            enrollmentDate = enrollment.EnrollmentDate;
            returnedFirstCuotaIfCancelledActivity = enrollment.ReturnedFirstCuotaIfCancelledActivity;
            userId = enrollment.User.Id;
            paymentIds = new List<int>();
            for (int i = 0; i < allIds.Length; i++)
            {
                paymentIds.Add(allIds[i].Id);
            }

        }

        public void GetGymData(out int gymId, out DateTime closingHour, out int discountLocal, 
            out int discountRetired, out double freeUserPrice, out string name, out DateTime openingHour, 
            out int zipCode, out ICollection<int> activityIds, out ICollection<int> roomIds)
        {
            if (cityHall.Gyms.Any())
            {
                gymId = gym.Id;
                closingHour = gym.ClosingHour;
                discountLocal = gym.DiscountLocal;
                discountRetired = gym.DiscountRetired;
                freeUserPrice = gym.FreeUserPrice;
                name = gym.Name;
                openingHour = gym.OpeningHour;
                zipCode = gym.ZipCode;
                activityIds = gym.Activities.Select(a => a.Id).ToList();
                roomIds = gym.Rooms.Select(r => r.Id).ToList();
            }
            else
            {
                throw new ServiceException("Currently Gym does not exist");
            }
        }

        public void GetInstructorDataFromId(string instructorId, out string address, out string IBAN, out string name, out int zipCode, out string ssn, out ICollection<int> activitiesIds)
        {
            Activity[] listaActividades = gym.Activities.ToArray();
            Boolean valor = true;
            ICollection<Instructor> listaInstructores = cityHall.getAllInstructors();

            address = "";
            IBAN = "";
            name = "";
            zipCode = 0;
            ssn = "";
            activitiesIds = new List<int>();

            foreach (Instructor ins in listaInstructores)
            {
                if (ins.Id == instructorId)
                {
                    valor = false;
                    address = ins.Address;
                    IBAN = ins.IBAN;
                    name = ins.Name;
                    zipCode = ins.ZipCode;
                    ssn = ins.Ssn;
                    foreach (Activity act in ins.Activities)
                    {
                        activitiesIds.Add(act.Id);
                    }
                }
            }

            if (valor) throw new ServiceException(); //no ha encontrado al instructor

        }
        public static bool inRange(DateTime horaAniadir, TimeSpan duracionAniadir, DateTime horaEnBd, TimeSpan duracionEnBd)
        {
            bool res = true;
            DateTime finHoraA = horaAniadir.AddSeconds(duracionAniadir.TotalSeconds);
            DateTime finHoraEnBd = horaEnBd.AddSeconds(duracionEnBd.TotalSeconds);

            if (horaAniadir > horaEnBd)
            {
                Console.WriteLine("horaAniadir > horaEnBd");
                if (finHoraEnBd > horaAniadir)
                {
                    Console.WriteLine("finHoraEnBd >= horaAniadir");
                    res = false;
                }
            }
            else if (horaAniadir < horaEnBd)
            {
                Console.WriteLine("horaAniadir < horaEnBd");
                if (finHoraA > horaEnBd)
                {
                    Console.WriteLine("finHoraA > horaEnBd");
                    res = false;
                }
            }
            else
            {
                if (horaAniadir.Hour == horaEnBd.Hour && horaAniadir.Minute == horaEnBd.Minute)
                {
                    Console.WriteLine("finHoraA.Hour == horaEnBd.Hour && finHoraA.Minute == horaEnBd.Minute");
                    res = false;
                }
            }
            Console.WriteLine();

            return res;
        }

        public ICollection<int> GetListAvailableRoomsIds(Days activityDays, TimeSpan duration, DateTime finishDate, DateTime startDate, DateTime startHour)
        {
            if(startDate > DateTime.Now)
            {
                if (startDate <=  finishDate)
                {
                    if (duration.TotalMinutes >0 && activityDays != Days.None)
                    {
                        
                        ICollection<Activity> IdActividades = gym.Activities.Where(a =>a.ActivityDays == activityDays
                                                                      && !inRange(startHour,duration,a.StartHour,a.Duration)).Select(a =>a).ToList();

                        ICollection<Room> idRomm = gym.Rooms.Select(r => r).ToList();

                        foreach (var IdR in gym.Rooms)
                        {
                            foreach (var act in IdActividades)
                            {
                                if (act.Rooms.Contains(IdR))
                                    idRomm.Remove(IdR);
                            }
                        }


                        return idRomm.Select(r=>r.Id).ToList();
                    }
                    else
                    {
                        throw new ServiceException("No puede ser la du");
                    }

                }
                else {
                    throw new ServiceException("La fecha debe ser mayor a la actual");
                }               
               
            }
            else
            {
                throw new ServiceException("La fecha debe ser igual o mayor a la actual.");
            }            
        }

        public Dictionary<DateTime, int> GetListAvailableRoomsPerWeek(DateTime initialMonday)
        {          

            if (initialMonday.DayOfWeek == DayOfWeek.Monday) {
                Dictionary<DateTime, int> resList = new Dictionary<DateTime, int>();

                DateTime fechaActual = new DateTime(initialMonday.Year, initialMonday.Month, initialMonday.Day,gym.OpeningHour.Hour,gym.OpeningHour.Minute,0);
                DateTime fechaFin = fechaActual.AddDays(7);

                DateTime horaFin = new DateTime(initialMonday.Year, initialMonday.Month, initialMonday.Day, gym.ClosingHour.Hour, gym.ClosingHour.Minute, 0);
                Days[] day = new Days[8];
                day[0] = Days.None;
                day[1] = Days.Mon;
                day[2] = Days.Thu;
                day[3] = Days.Wed;
                day[4] = Days.Tue;
                day[5] = Days.Fri;
                day[6] = Days.Sun;
                day[7] = Days.Sat;
                int i =1;
                var daysOfW = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();


                for (; fechaActual < fechaFin; fechaActual= fechaActual.AddDays(1))
                {
                    //Es que no compruebas si hay dos actividades que se desarrollan al mismo tiempo y en el mismo cuarto
                    for (DateTime horaActual = gym.OpeningHour; horaActual < gym.ClosingHour; horaActual = horaActual.AddMinutes(45))
                    {
                        DateTime horaInsertar = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, horaActual.Hour, horaActual.Minute, horaActual.Second);
                        
                        var act = gym.Activities.Where(a => !a.ActivityDays.HasFlag(day[i]) || (a.ActivityDays.HasFlag(day[i]) && !inRange(horaInsertar, TimeSpan.FromMinutes(45), new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day,
                                a.StartHour.Hour, a.StartHour.Minute, a.StartHour.Second), a.Duration)) );

                        int cont = 0;
                        foreach(var a in act)
                        {
                            var roms = a.Rooms.Where(r => a.Rooms.Count() > 0);

                            if (roms.Count()>0)
                                cont++;
                        }
                        
                
                        resList.Add(horaInsertar, gym.Rooms.Count()-cont);
                    }
                    i ++;

                }



                return resList;
            }        
            else
            {
                throw new ServiceException("The start date must be a Monday");
            }
        }

        public void GetPaymentDataFromId(int paymentId, out DateTime date, out string description, out double quantity)
        {
            Payment payment = cityHall.getPaymentById(paymentId);

            if (paymentId < 0) // Checks if the paymentId is negative (invalid)
            {
                throw new ServiceException("ERROR: The paymentId is invalid");
            }

            if (payment == null) // Checks if the payment exists
            {
                throw new ServiceException("ERROR: The payment does not exist");
            }

            date = payment.Date;
            description = payment.Description;
            quantity = payment.Quantity;
        }

        public void GetRoomDataFromId(int roomId, out int number, out ICollection<int> activityIds)
        {
            if (roomId >= 0)
            {
                // Las salas pertenecen a los gimnasios, por lo que buscaremos está sala en gym
                try
                {
                    Room sala = gym.Rooms.First(r => r.Id == roomId);
                    number = sala.Number;
                    activityIds = sala.Activities.Select(s => s.Id).ToList();
                }
                catch (InvalidOperationException excpt) {                   
                    number = -1;
                    activityIds = null;
                    Console.Error.WriteLine("Error: no existe sala con el id: {0}", roomId);
                    throw new ServiceException($"La sala con id: {roomId} no existe en la BD.");
                }             
            }
            else
            {
                throw new ServiceException("El parámetro roomId no es valido. El identificador debe ser positivo");
            }

        }
        public void GetUserDataFromId(string userId, out string address, out string iban, out string name, out int zipCode, out DateTime birthDate, out bool retired, out ICollection<int> enrollmentIds)
        {
            User user = cityHall.getUserById(userId);
            

            address = "";
            iban = "";
            name = "";
            zipCode = 0;
            birthDate = new DateTime();
            retired = false;
            enrollmentIds = new List<int>();

            if (user == null) // Checks if the user exists or the userId has been incorrectly introduced
            {
                throw new ServiceException("ERROR: A user with this ID does not exist");
            }
            Enrollment[] allIds = user.Enrollments.ToArray();
            address = user.Address;
            iban = user.IBAN;
            name = user.Name;
            zipCode = user.ZipCode;
            birthDate = user.BirthDate;
            retired = user.Retired;
        
               for (int i = 0; i < allIds.Length; i++)
               {
                    enrollmentIds.Add(allIds[i].Id);
               }
            


        }


        public double GetUserDataNotInActivityAndFirstQuota(int activityId, string userId, out string address, out string iban, out string name, out int zipCode, out DateTime birthDate, out bool retired, out ICollection<int> enrollmentIds)
        {
            if (activityId <= 0) // Checks if the activityId is negative
            {
                throw new ServiceException("ERROR: The ID of the activity is invalid");
            }

            if (userId == null) // Checks if the userId is empty
            {
                throw new ServiceException("ERROR: The ID of the activity is invalid");
            }

            Activity activity = gym.getActivityById(activityId);

            if (activity == null) // Checks if the activity exists
            {
                throw new ServiceException("ERROR: The activity does not exist");
            }

            User user = cityHall.getUserById(userId);

            if (user == null) // Checks if the user exists
            {
                throw new ServiceException("ERROR: The user does not exist");
            }

            if (activity.enrolledToActivity(user, activity)) // Checks if the userId is signed up to that specific activity
            {
                throw new ServiceException("ERROR: The user is already signed up to the activity");
            }

            Enrollment[] allIds = user.Enrollments.ToArray();
            double quota = activity.calculateQuota(user, gym.DiscountLocal, gym.DiscountRetired, gym.ZipCode);
            address = user.Address;
            iban = user.IBAN;
            name = user.Name;
            zipCode = user.ZipCode;
            birthDate = user.BirthDate;
            retired = user.Retired;
            enrollmentIds = new List<int>();
            for (int i = 0; i < allIds.Length; i++)
            {
                enrollmentIds.Add(allIds[i].Id);
            }

            return quota;
        }

        #region Connection with the Persistence Layer
        public void RemoveAllData()
        {
            dal.RemoveAllData();
        }

     
        public void SaveChanges()
        {
            dal.Commit();
        }
        #endregion
    }
}
