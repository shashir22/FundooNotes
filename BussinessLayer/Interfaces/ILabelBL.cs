using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ILabelBL
    {
        Task Addlabel(int userId, int Noteid, string LabelName);
        Task<List<RepositoryLayer.Entity.Label>> Getlabel(int userId);
        Task<List<RepositoryLayer.Entity.Label>> GetlabelByNoteId(int NoteId);
        Task<RepositoryLayer.Entity.Label> UpdateLabel(int userId, int LabelId, string LabelName);
        Task DeleteLabel(int LabelId, int userId);
    }
}
