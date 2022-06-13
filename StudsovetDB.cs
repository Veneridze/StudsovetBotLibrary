using MySql.Data.MySqlClient;
using StudsovetBot.drivers;
using StudsovetBot.objects;
using System;

namespace StudsovetBot
{
    public class StudsovetDB
    {
        MySqlDriver db;
        public StudsovetDB(string ip, string database, string login, string pass, uint port = 3306)
        {
            db = new MySqlDriver(ip, database, login, pass, port);
        }

        public Op GetOp(uint op_num)
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo($"SELECT * FROM `op` WHERE `number` = {op_num} LIMIT 1");
            if (reader.HasRows)
            {
                reader.Read();
                Op result = new Op()
                {
                    num = reader.GetByte(0),
                    name = reader.GetString(1),
                    address = reader.GetString(2),
                    //structure = reader.
                };
                reader.Close();
                return result;
            }
            else
            {
                throw new Exception($"Площадка с номером {op_num} не найдена");
            }

        }

        public List<Op> GetOpList()
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo("SELECT * FROM `op`");
            List<Op> result = new List<Op>();
            if (reader.HasRows)
            {
                reader.Read();
                result.Add(new Op()
                {
                    num = reader.GetByte(0),
                    name = reader.GetString(1),
                    address = reader.GetString(2),
                    //structure = (string)reader.GetValue(3)
                }
                );
                reader.Close();
            }
            return result;
        }

        public Project GetProject(uint id = 0)
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo($"SELECT * FROM `projects` WHERE `id` = {id} LIMIT 1");
            if (reader.HasRows)
            {
                reader.Read();
                Project result = new Project() { id = reader.GetByte(0), title = reader.GetString(1), about = reader.GetString(2), target = reader.GetString(3), result = reader.GetString(4) };
                reader.Close();
                return result;
            }
            else
            {
                throw new Exception($"Проект с id {id} не найден");
             }

        }


        public List<Project> GetProjectList()
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo("SELECT * FROM `projects`");
            List<Project> result = new List<Project>();
            if (reader.HasRows)
            {
                reader.Read();
                result.Add(new Project()
                {
                    id = reader.GetUInt16(0),
                    title = reader.GetString(1),
                    about = reader.GetString(2),
                    target = reader.GetString(3),
                    result = reader.GetString(4),
                }
                );
                reader.Close();
            }
            return result;
        }
        public List<LinkBtn> GetProjectLinksList(uint project_id)
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo($"SELECT * FROM `project_links` WHERE `project_id` = {project_id}");
            List<LinkBtn> result = new List<LinkBtn>();
            if (reader.HasRows)
            {
                reader.Read();
                result.Add(new LinkBtn()
                {
                    id = reader.GetUInt16(0),
                    project_id = reader.GetUInt16(1),
                    title = reader.GetString(2),
                    link = reader.GetString(3)
                }
                );
                reader.Close();
            }
            return result;
        }

        public List<Sector> GetSectorList()
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo("SELECT * FROM `sectors`");
            List<Sector> result = new List<Sector>();
            if (reader.HasRows)
            {
                reader.Read();
                result.Add(new Sector()
                {
                    id = reader.GetByte(0),
                    title = reader.GetString(1),
                    about = reader.GetString(2),
                    //photo = reader.GetString(),
                }
                );
                reader.Close();
            }
            return result;
        }

        public Sector GetSector(uint id)
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo($"SELECT * FROM `sectors` WHERE `id` = {id}");
            if (reader.HasRows)
            {
                reader.Read();
                Sector result = new Sector()
                {
                    id = reader.GetByte(0),
                    title = reader.GetString(1),
                    about = reader.GetString(2),
                    
                //photo = reader.GetValue(),
                };
                reader.Close();
                return result;            }
            else
            {
                throw new Exception($"Сектор с id {id} не найден");
           ;}
        }

        public List<Student> GetRateList()
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo("SELECT * FROM `students` ORDER BY `points` DESC");
            List<Student> result = new List<Student>();
            if (reader.HasRows)
            {
                reader.Read();
                result.Add(new Student()
                {
                    id = reader.GetUInt16(0),
                    name = reader.GetString(1),
                    group = reader.GetString(2),
                    op = reader.GetByte(3),
                    point = reader.GetUInt16(4),
                }
                );
                reader.Close();
            }
            return result;
        }

        public Student GetStudent(int id)
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo($"SELECT * FROM `students` WHERE `id` = {id} LIMIT 1");
            if (reader.HasRows)
            {
                reader.Read();
                Student result = new Student()
                {
                    id = reader.GetUInt16(0),
                    name = reader.GetString(1),
                    group = reader.GetString(2),
                    op = reader.GetByte(3),
                    point = reader.GetUInt16(4),
                };
                reader.Close();
                return result;
            }
            else
            {
                throw new Exception($"Студент с id {id} не найден");
            }
        }

        public List<Contact> GetContactList()
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo("SELECT * FROM `contacts` ORDER BY `priority` DESC");
            List<Contact> result = new List<Contact>();
            if (reader.HasRows)
            {
                reader.Read();
                result.Add(new Contact()
                {
                    id = reader.GetByte(0),
                    priority = reader.GetByte(1),
                    name = reader.GetString(2),
                    post = reader.GetString(3),
                    phone = reader.GetDecimal(4),
                    tg_link = reader.GetString(5),
                    vk_link = reader.GetString(6)
                }
                );
                reader.Close();
            }
            return result;
        }

        public Contact GetContact(int id)
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo($"SELECT * FROM `contacts` WHERE `id` = {id} LIMIT 1");
            if (reader.HasRows)
            {
                reader.Read();
                Contact result = new Contact()
                {
                    id = reader.GetByte(0),
                    priority = reader.GetByte(1),
                    name = reader.GetString(2),
                    post = reader.GetString(3),
                    phone = reader.GetDecimal(4),
                    tg_link = reader.GetString(5),
                    vk_link = reader.GetString(6)
                };
                reader.Close();
                return result;
            }
            else
            {
                throw new Exception($"Контакт с id {id} не найден");
            }
        }
        public List<OpDelegate> GetDelegateList()
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo("SELECT * FROM `op_delegates`");
            List<OpDelegate> result = new List<OpDelegate>();
            if (reader.HasRows)
            {
                reader.Read();
                result.Add(new OpDelegate()
                {
                    op = reader.GetByte(0),
                    name = reader.GetString(1),
                    about = reader.GetString(2),
                    //photo = reader.GetString(3)
                }
                );
                reader.Close();
            }
            return result;
        }

        public OpDelegate GetDelegate(int op)
        {
            MySqlDataReader reader = (MySqlDataReader)db.GetInfo($"SELECT * FROM `op_delegates` WHERE `op` = {op} LIMIT 1");
            if (reader.HasRows)
            {
                reader.Read();
                OpDelegate result = new OpDelegate()
                {
                    op = reader.GetByte(0),
                    name = reader.GetString(1),
                    about = reader.GetString(2),
                    //photo = reader.GetString(3)
                };
                reader.Close();
                return result;
            }
            else
            {
                throw new Exception($"Представитель с оп {op} не найден");
            }
        }
    }
}