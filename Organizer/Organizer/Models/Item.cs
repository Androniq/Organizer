using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Organizer.Models
{
    public class Item
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
