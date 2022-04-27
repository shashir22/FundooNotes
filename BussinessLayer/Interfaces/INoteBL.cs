using DatabaseLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface INoteBL
    {
        public Task AddNote(NotePostModel notePostModel, int userID);
        public Task<Note> GetNote(int noteId, int userId);

    }
}
