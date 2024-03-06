﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QR_Menu.Models
{
	public class Category
	{
		public int Id { get; set; }
		[StringLength(50)]
		[Column(TypeName = "nvarchar(50)")]
		public string Name { get; set; } = "";
		public byte StateId { get; set; }
		public int RestaurantId { get; set; }

		[ForeignKey("StateId")]
		public State? State { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant? Restaurant { get; set; }
    }
}

