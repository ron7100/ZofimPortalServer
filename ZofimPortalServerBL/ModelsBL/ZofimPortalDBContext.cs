﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZofimPortalServerBL.Models
{
    public partial class ZofimPortalDBContext:DbContext
    {
        //שלוש פעולות שונות שמנסות לחבר לכל סוג של משתמש, שתיים ייכשלו ורק הסוג הנכון יצליח
        //פעולה אחת שמחזירה אובייקט ובודקת לפי המשתמש איזה סוג אובייקט זה
        
        public Object Login(string uName, string pass)
        {
            #region האם המשתמש קיים
            User user = this.Users.Where(u => u.Username == uName && u.Password == pass).FirstOrDefault();
            if (user == null)
                return null;//במקום בו קוראים לפעולה בודקים אם האובייקט שחזר ריק. אם כן, ההתחברות נכשלה
            #endregion

            #region מציאת סוג המשתמש
            object objToReturn = this.Workers.Where(w => w.UserId == user.Id).Include(w=>w.Shevet).ThenInclude(w=>w.Hanhaga).FirstOrDefault();
            if(objToReturn==null)//בודק האם המשתמש הוא עובד
            {
                objToReturn = this.Parents.Where(p => p.UserId == user.Id).Include(p => p.Shevet).ThenInclude(p => p.Hanhaga).FirstOrDefault();
                if (objToReturn == null)//בודק האם המשתמש הוא הורה
                    objToReturn = this.Cadets.Where(c => c.UserId == user.Id).Include(c => c.Shevet).ThenInclude(c => c.Hanhaga).FirstOrDefault();
                    //אם המשתמש לא עובד ולא הורה, אז המשתמש הוא חניך
            }
            return objToReturn;//מחזיר את המשתמש בתור הסוג של המשתמש
            #endregion
        }
        public bool IsUserExist(string uName)
        {
            User user = this.Users.Where(u => u.Username == uName).FirstOrDefault();
            return user != null;
        }

        public void SignUp(User user)
        {
            this.Users.Add(user);
            this.SaveChanges();
        }
    }         
}
