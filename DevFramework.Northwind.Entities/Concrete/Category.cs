﻿using System;
using System.Collections.Generic;
using System.Text;
using DevFramework.Core.Entities;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class Category:IEntity
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
