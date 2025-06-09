using litfibretestapi.Models.Data;
using litfibretestapi.Models;
using litfibretestapi.Interfaces;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace litfibretestapi.Datatabase.Real
{ 
    public class MemoryDatabase<T> : IMemoryDatabase<T> where T : DatabaseObject{
        private Dictionary<string, T> appointmentsTable = new Dictionary<string, T>();

        public MemoryDatabase()
        {
            //Seed Appointments table
            // List<T> appointments = JsonConvert.DeserializeObject<List<T>>(seedData?["appointments"].ToString());

            // foreach (var appointment in appointments)
            // {
            //     appointment.Id = Guid.NewGuid().ToString();
            //     this.appointmentsTable.Add(appointment.Id, appointment);
            // }
        }


        /// <summary>
        /// Retrieve an Appointment from the database
        /// </summary>
        /// <param name="id">ID of the Appointment</param>
        /// <returns>Appointment with ID id or null</returns>
        public T? Read(string id){
                if(this.appointmentsTable.ContainsKey(id)){
                    return this.appointmentsTable[id];
                }
                return null;
            }


            /// <summary>
            /// Insert or update an Appointment in the database
            /// </summary>
            /// <param name="item">Appointment to insert or update. If the Appointment's ID matches and existing ID in the database, it will be updated</param>
            public void Push(T item){
                if(!this.appointmentsTable.ContainsKey(item.Id) || item.Id == null){
                    // Give it a Guid
                    item.Id = Guid.NewGuid().ToString();
                    this.appointmentsTable.Add(item.Id, item);
                }
                else {
                    this.appointmentsTable[item.Id] = item;
                }
            }

            /// <summary>
            /// Deletes an Appointment from the database
            /// </summary>
            /// <param name="id">ID of the Appointment to delete</param>
            public void Delete(string id){
                if(this.appointmentsTable.ContainsKey(id)){
                    this.appointmentsTable.Remove(id);
                }
            }
            
            /// <summary>
            /// Deletes an Appointment from the database
            /// </summary>
            /// <param name="item">The Appointment to delete</param>
            public void Delete(T item){
                if(this.appointmentsTable.ContainsKey(item.Id)){
                    this.appointmentsTable.Remove(item.Id);
                }
            }

            /// <summary>
        /// Queries the entire database using a predicate
        /// </summary>
        /// <param name="predicate">Predicate that will be run against all Appointments in the database</param>
        /// <returns>The results of the query</returns>
        public IEnumerable<T> Query(Predicate<T> predicate)
        {
            return appointmentsTable.Values.Where(Appointment => predicate(Appointment));
        }
    }
}
