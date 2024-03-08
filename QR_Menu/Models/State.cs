using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QR_Menu.Models
{
	public class State
	{
		[Key]//Primary Key
		[DatabaseGenerated(DatabaseGeneratedOption.None)]//Identy Olmasın
		public byte Id { get; set; }

		[Required]//Frontendde gerekli olduğunu belirtir.
		[StringLength(10)]//Maksimum 10 deger alır.
		[Column(TypeName = "nvarchar(10)")]//Veritabanındaki tipini verdim.
		public string Name { get; set; } = "";
		// deneme
	}
}