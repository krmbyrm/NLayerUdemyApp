using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entity
{
    public abstract class BaseEntity
    {
       
        public int Id { get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
