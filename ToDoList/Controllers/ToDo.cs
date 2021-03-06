﻿using System;

namespace ToDoList.Controllers
{
    public class ToDo
    {
        public ToDo()
        {
            CreateDate = DateTime.Now;
            Guid = Guid.NewGuid();
            Overline = false;
        }

        public Guid Guid { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Overline { get; set; }
    }
}