using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataAccessLayer.Entity;

namespace MyDataAccessLayer
{
   public interface ICricketersDetailsRepository
    {
        public List<CricketDetails> SelectALLUser();

        public CricketDetails SelectUserByUsername(string username);

        public void RegisterUser(CricketDetails cric);

        public void UpdateUser(CricketDetails value);

        public void DeleteUser(long Id);
    }
}
