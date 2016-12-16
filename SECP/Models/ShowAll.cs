using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SECP.Models;

namespace SECP.Models
{
    public class ShowAll
    {
        SECPDataContext db = new SECPDataContext();

        private List<SimpleInfo> tpxw;
        public List<SimpleInfo> Tpxw
        {
            get
            {
                return tpxw;
            }
            set
            {
                tpxw = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 2).Select(x => x).Take(3).ToList();
            }
        }

        private List<SimpleInfo> yw;
        public List<SimpleInfo> Yw
        {
            get
            {
                return yw;
            }
            set
            {
                yw = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 1).Select(x => x).Take(3).ToList();
            }
        }

        private List<SimpleInfo> gnwkjgz;
        public List<SimpleInfo> Gnwkjgz
        {
            get
            {
                return gnwkjgz;
            }
            set
            {
                gnwkjgz = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 5).Select(x => x).Take(3).ToList();
            }
        }

        private List<SimpleInfo> kjbgz;
        public List<SimpleInfo> Kjbgz
        {
            get
            {
                return kjbgz;
            }
            set
            {
                kjbgz = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 4).Select(x => x).Take(3).ToList();
            }
        }

        private List<SimpleInfo> dfkjgz;
        public List<SimpleInfo> Dfkjgz
        {
            get
            {
                return dfkjgz;
            }
            set
            {
                dfkjgz = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 3).Select(x => x).Take(3).ToList();
            }
        }


        private List<SimpleInfo> kjgh;
        public List<SimpleInfo> Kjgh
        {
            get {return kjgh ;}
            set { kjgh = db.SimpleInfo.Where(s => s.Category1 == 1 && s.Category2 == 0).Select(s => s).Take(3).ToList(); }
        }
        private List<SimpleInfo> zjgk;
        public List<SimpleInfo> Zjgk
        {
            get { return zjgk; }
            set { zjgk = db.SimpleInfo.Where(s => s.Category1 == 1 && s.Category2 == 1).Select(s => s).Take(3).ToList(); }
        }
        private List<SimpleInfo> kjzc;
        public List<SimpleInfo> Kjzc
        {
            get { return kjzc; }
            set { kjzc = db.SimpleInfo.Where(s => s.Category1 == 0).Select(s => s).Take(3).ToList(); }
        }
        public ShowAll()
        {
            this.yw = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 1).Select(x => x).Take(3).ToList();
            //this.tpxw = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 2).Select(x => x).Take(3).ToList();
            //this.gnwkjgz = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 5).Select(x => x).Take(3).ToList();
            //this.kjbgz = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 4).Select(x => x).Take(3).ToList();
            //this.dfkjgz = db.SimpleInfo.Where(s => s.Category1 == 2 && s.Category2 == 3).Select(x => x).Take(3).ToList();
            //this.zjgk = db.SimpleInfo.Where(s => s.Category1 == 1 && s.Category2 == 1).Select(s => s).Take(3).ToList();
            this.kjzc = db.SimpleInfo.Where(s => s.Category1 == 0).Select(s => s).Take(3).ToList();
            this.kjgh = db.SimpleInfo.Where(s => s.Category1 == 1 && s.Category2 == 0).Select(s => s).Take(3).ToList();
            this.zjgk = db.SimpleInfo.Where(s => s.Category1 == 1 && s.Category2 == 1).Select(s => s).Take(3).ToList(); 
        }
    }
}