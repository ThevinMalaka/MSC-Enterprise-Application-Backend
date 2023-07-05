﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace courseworkBackend.Entities
{
	public class PredictionModel
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public double Weight { get; set; }
		public UserModel User { get; set; }
		[ForeignKey("User")]
		public int UserId { get; set; }
	}
}

