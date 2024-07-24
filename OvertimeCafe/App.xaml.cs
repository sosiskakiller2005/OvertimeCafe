using OvertimeCafe.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OvertimeCafe
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static OvertimeDbEntities _context;
        public static OvertimeDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new OvertimeDbEntities();
            }
            return _context;
        }
    }
}
