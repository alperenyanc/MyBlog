using MyBlog.DAL.ORM.Enum;
using MyBlog.DAL.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Entity
{
    public class BaseEntity : ICore
    {
        public Guid ID { get; set ; }

        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate { get {return _addDate  ; } set {_addDate=value ; } }
        private DateTime _upDate = DateTime.Now;
        public DateTime UpdateDate { get { return _upDate; } set { _upDate = value; } }
        private DateTime _deleteDate = DateTime.Now;
        public DateTime DeleteDate { get { return _deleteDate; } set { _deleteDate = value; } }
        private Status _status = ORM.Enum.Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
