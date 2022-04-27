using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooNotesContext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        // Created The User Repository Layer Class To Implement IUserRL Methods
        // Reference Object For FundooContext And IConfiguration
        FundooContext fundoo;
        private readonly IConfiguration Toolsettings;

        //Created Constructor To Initialize Fundoocontext For Each Instance
        public NoteRL(FundooContext fundoo, IConfiguration Toolsettings)
        {
            this.fundoo = fundoo;
            this.Toolsettings = Toolsettings;
        }

        public async Task AddNote(NotePostModel notePostModel, int userId)
        {
            // throw new NotImplementedException();
            try
            {
                var user = fundoo.Users.FirstOrDefault(u => u.UserId == userId);
                Note note = new Note
                {
                    User = user
                };
                note.Title = notePostModel.Title;
                note.Description = notePostModel.Description;
                note.BGColor = notePostModel.BGColor;
                note.IsArchive = notePostModel.IsArchive;
                note.IsReminder = notePostModel.IsReminder;
                note.IsPin = notePostModel.IsPin;
                note.IsTrash = notePostModel.IsTrash;

                fundoo.Add(note);
                await fundoo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Note> GetNote(int noteId, int userId)
        {
            try
            {
                return await fundoo.Notes.Where(u => u.NoteId == noteId && u.UserId == userId)
                   .Include(u => u.User).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}