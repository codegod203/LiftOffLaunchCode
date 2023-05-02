
using System;
using System.ComponentModel.DataAnnotations;
using Moonwalkers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Moonwalkers.ViewModels
{
    public class AddInventoryViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string? Description { get; set; }

        [EmailAddress]
        public string? ContactEmail { get; set; }

        public InventoryType Type { get; set; }

        public List<SelectListItem> InventoryTypes { get; set; } = new List<SelectListItem>
        {
           new SelectListItem(InventoryType.Conference.ToString(), ((int)InventoryType.Conference).ToString()),
           new SelectListItem(InventoryType.Meetup.ToString(), ((int)InventoryType.Meetup).ToString()),
           new SelectListItem(InventoryType.Social.ToString(), ((int)InventoryType.Social).ToString()),
           new SelectListItem(InventoryType.Workshop.ToString(), ((int)InventoryType.Workshop).ToString())
        };
    }
}
