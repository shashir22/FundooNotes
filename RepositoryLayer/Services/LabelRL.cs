using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.FundooNotesContext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        FundooContext fundoo;
        public IConfiguration Configuration { get; }
        public LabelRL(FundooContext fundoo, IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.fundoo = fundoo;
        }
        public async Task Addlabel(int userId, int Noteid, string LabelName)
        {
            try
            {
                var user = fundoo.Users.FirstOrDefault(u => u.UserId == userId);
                var note = fundoo.Notes.FirstOrDefault(b => b.NoteId == Noteid);
                Entity.Label label = new Entity.Label
                {
                    User = user,
                    Note = note
                };
                label.LabelName = LabelName;
                fundoo.Labels.Add(label);
                await fundoo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Entity.Label>> Getlabel(int userId)
        {
            try
            {
                List<Entity.Label> reuslt = await fundoo.Labels.Where(u => u.userId == userId).Include(u => u.User).Include(u => u.Note).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Entity.Label>> GetlabelByNoteId(int NoteId)
        {
            try
            {
                List<Entity.Label> reuslt = await fundoo.Labels.Where(u => u.NoteId == NoteId).Include(u => u.User).Include(u => u.Note).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Entity.Label> UpdateLabel(int userId, int LabelId, string LabelName)
        {
            try
            {

                Entity.Label reuslt = fundoo.Labels.FirstOrDefault(u => u.LabelId == LabelId && u.userId == userId);

                if (reuslt != null)
                {
                    reuslt.LabelName = LabelName;
                    await fundoo.SaveChangesAsync();
                    var result = fundoo.Labels.Where(u => u.LabelId == LabelId).FirstOrDefaultAsync();
                    return reuslt;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteLabel(int LabelId, int userId)
        {
            try
            {
                var result = fundoo.Labels.FirstOrDefault(u => u.LabelId == LabelId && u.userId == userId);
                fundoo.Labels.Remove(result);
                await fundoo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
       