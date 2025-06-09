using litfibretestapi.Models;
using litfibretestapi.Models.Data;
using litfibretestapi.Interfaces;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// All this does is provide an example Appointment object when Read is called

namespace litfibretestapi.Datatabase.Mock
{
    public class MockMemoryDatabase : IMemoryDatabase<DatabaseObject>
    {
        private Dictionary<string, DatabaseObject> appointmentsTable = new Dictionary<string, DatabaseObject>();


        private MockMemoryDatabase()
        {
            string exampleId = Guid.NewGuid().ToString();
            Appointment exampleAppointment = new Appointment(new Slot()
            {
                Start = DateTime.Parse("2025-06-16T13:00:00+01:00"),
                End = DateTime.Parse("2025-06-16T17:00:00+01:00"),
                appointmentType = Enums.AppointmentType.Installation
            },
             Enums.AppointmentType.Installation,
             Enums.AppointmentStatus.Booked
             )
            { Id = exampleId };
            this.appointmentsTable.Add(exampleId, exampleAppointment);
        }


        /// <summary>
        /// Retrieve an Appointment from the database
        /// </summary>
        /// <param name="id">ID of the Appointment</param>
        /// <returns>Appointment with ID id or null</returns>
        public DatabaseObject Read(string id)
        {
            //Slot appointmentSlot = new();
            return this.appointmentsTable.First().Value;
        }

        /// <summary>
        /// Insert or update an Appointment in the database
        /// </summary>
        /// <param name="item">Appointment to insert or update. If the Appointment's ID matches and existing ID in the database, it will be updated</param>
        public void Push(DatabaseObject item)
        {

        }

        /// <summary>
        /// Deletes an Appointment from the database
        /// </summary>
        /// <param name="id">ID of the Appointment to delete</param>
        public void Delete(string id)
        {

        }

        /// <summary>
        /// Deletes an Appointment from the database
        /// </summary>
        /// <param name="item">The Appointment to delete</param>
        public void Delete(DatabaseObject item)
        {

        }

        /// <summary>
        /// Queries the entire database using a predicate
        /// </summary>
        /// <param name="predicate">Predicate that will be run against all Appointments in the database</param>
        /// <returns>The results of the query</returns>
        public IEnumerable<DatabaseObject> Query(Predicate<DatabaseObject> predicate)
        {
            return appointmentsTable.Values.Where(Appointment => predicate(Appointment));
        }
    }
}