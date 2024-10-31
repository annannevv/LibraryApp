using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    internal interface ILoggerService
    {
        void LogInfo(string message);
        void NotifyBookAdded();
        void NotifyBookExists();
        void NotifyBookDeleted();
        void NotifyBookNotFound();
        void ShowMenu();
        void NotifyInvalidNumber();
    }
}
