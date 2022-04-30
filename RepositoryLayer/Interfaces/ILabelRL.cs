using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRL
    {
        Task Addlabel(int userId, int Noteid, string LabelName);
        Task<List<Entity.Label>> Getlabel(int userId);
        Task<List<Entity.Label>> GetlabelByNoteId(int NoteId);
        Task<Entity.Label> UpdateLabel(int userId, int LabelId, string LabelName);
        Task DeleteLabel(int LabelId, int userId);
    }
}
