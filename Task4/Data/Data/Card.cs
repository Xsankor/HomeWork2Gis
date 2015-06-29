using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class Card
    {
        private string _name;
        private long SynCode;
        private long Id;
        
        public Card(long id, long synCode, string name)
        {
            Id = id;
            SynCode = synCode;
            _name = name;
        }
        public Card()
        {
            Id = 0;
            SynCode = 1;
            _name = "New project";
        }
        public long ChangeProjectId()
        {
            if ((Id == 0) || (Id - SynCode != 100))
                Id = SynCode + 100;
            return Id;
        }
        public string GetProjectName()
        {
            if (_name != "New project")
            {
                _name = _name + Convert.ToString(SynCode);
            }
            else
            {
                _name = "Project" + Convert.ToString(SynCode);
            }
            return _name;
        }
        public string GetProjectInfo()
        {
            return string.Format("Проект {0}, id={1}, SynCode={2}", _name, Id, SynCode);
        }
        public void ChangeDeletedProject()
        {
            _name = _name + "_DELETED";
        }
        
    }
}
