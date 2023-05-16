using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moonwalkers.Data;
using Moonwalkers.Models;
using MySqlConnector;

namespace Moonwalkers.Controllers
{
    public class CalendarController : Controller

    {
        private readonly InventoryDbContext context; // Add this line

        public CalendarController(InventoryDbContext context) // Add this constructor
        {
            context = context;
        }
        private readonly string connectionString = "server=localhost;user=inventorymanagement;password=inventorymanagement;database=inventorymanagement";

        public IActionResult Index()
        {
            List<EventModel> events = GetEventsFromDatabase(); // Retrieve events from the database
            return View(events);
        }

        [HttpPost]
        public IActionResult AddEvent(EventModel newEvent)
        {
            if (ModelState.IsValid)
            {
                context.Events.Add(newEvent);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Handle invalid model state
            return View(newEvent);
        }



        [HttpPost]
        public IActionResult UpdateEvent(EventModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateEventInDatabase(model); // Update the event in the database
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteEvent(int eventId)
        {
            DeleteEventFromDatabase(eventId); // Delete the event from the database
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private List<EventModel> GetEventsFromDatabase()
        {
            List<EventModel> events = new List<EventModel>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM events";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EventModel eventModel = new EventModel
                    {
                        EventId = Convert.ToInt32(reader["EventId"]),
                        Title = reader["Title"].ToString(),
                        Start = Convert.ToDateTime(reader["Start"]),
                        End = Convert.ToDateTime(reader["End"])
                    };
                    events.Add(eventModel);
                }

                reader.Close();
            }

            return events;
        }

        private void SaveEventToDatabase(EventModel model)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO events (Title, Start, End) VALUES (@Title, @Start, @End)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", model.Title);
                command.Parameters.AddWithValue("@Start", model.Start);
                command.Parameters.AddWithValue("@End", model.End);
                command.ExecuteNonQuery();

            }
        }

        private void UpdateEventInDatabase(EventModel model)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE events SET Title = @Title, Start = @Start, End = @End WHERE EventId = @EventId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventId", model.EventId);
                command.Parameters.AddWithValue("@Title", model.Title);
                command.Parameters.AddWithValue("@Start", model.Start);
                command.Parameters.AddWithValue("@End", model.End);
                command.ExecuteNonQuery();
            }
        }

        private void DeleteEventFromDatabase(int eventId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM events WHERE EventId = @EventId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventId", eventId);
                command.ExecuteNonQuery();
            }
        }
    }
}
