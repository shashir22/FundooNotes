using BussinessLayer.Interfaces;
using DatabaseLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        public async Task Addlabel(int userId, int Noteid, string LabelName)
        {
            try
            {
                await this.labelRL.Addlabel(userId, Noteid, LabelName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<RepositoryLayer.Entity.Label>> Getlabel(int userId)
        {
            try
            {
                return await this.labelRL.Getlabel(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<RepositoryLayer.Entity.Label>> GetlabelByNoteId(int NoteId)
        {
            try
            {
                return await this.labelRL.Getlabel(NoteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RepositoryLayer.Entity.Label> UpdateLabel(int userId, int LabelId, string LabelName)
        {
            try
            {
                return await this.labelRL.UpdateLabel(userId, LabelId, LabelName);
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
                await this.labelRL.DeleteLabel(LabelId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}