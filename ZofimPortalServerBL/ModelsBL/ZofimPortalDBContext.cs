using System;
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
        
        public User Login(string uName, string pass)
        {
            #region האם המשתמש קיים
            User user = this.Users.Where(u => u.Username == uName && u.Password == pass).FirstOrDefault();
            return user;
            #endregion

            //#region מציאת סוג המשתמש
            //User objToReturn = this.Workers.Where(w => w.UserId == user.Id).Include(w => w.Shevet).ThenInclude(w => w.Hanhaga).FirstOrDefault();
            //if(objToReturn==null)//בודק האם המשתמש הוא עובד
            //    objToReturn = this.Parents.Where(p => p.UserId == user.Id).Include(p => p.Shevet).ThenInclude(p => p.Hanhaga).FirstOrDefault();//אם המשתמש הוא לא עובד, אז הוא הורה
            //return this.Users.Where(u=>;//מחזיר את המשתמש בתור הסוג של המשתמש
            //#endregion
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
