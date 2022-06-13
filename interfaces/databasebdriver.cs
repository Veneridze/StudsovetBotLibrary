using System.Data;

namespace StudsovetBot.interfaces
{
    internal interface Idatabasebdriver
    {
        public IDataReader GetInfo(string query);
        
    }
}
