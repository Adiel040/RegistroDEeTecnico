using Microsoft.EntityFrameworkCore;
using RegistroDEeTecnico.DAL;
using RegistroDEeTecnico.Models;
using System.Linq.Expressions;

namespace RegistroDEeTecnico.Services
{
    public class IncentivosTecnicoServices
    {
        private readonly Contexto _context;

        public IncentivosTecnicoServices(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int IncentivoId)
        {
            return await _context.IncentivosTecnicos.AnyAsync(t => t.IncentivoId == IncentivoId);
        }

        public async Task<bool> Existe(string descripcion)
        {
            return await _context.IncentivosTecnicos.AnyAsync(i => i.Descripcion == descripcion);
        }

        private async Task<bool> Insertar(IncentivosTecnicos incentivosTecnicos)
        {
            _context.IncentivosTecnicos.Add(incentivosTecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(IncentivosTecnicos incentivosTecnicos)
        {
            _context.IncentivosTecnicos.Update(incentivosTecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(IncentivosTecnicos incentivosTecnicos)
        {
            if (!await Existe(incentivosTecnicos.IncentivoId))
                return await Insertar(incentivosTecnicos);
            else
                return await Modificar(incentivosTecnicos);
        }

        public async Task<bool> Eliminar(int id)
        {
            var incentivosTecnicos = await _context.IncentivosTecnicos
                .Where(i => i.IncentivoId == id)
                .ExecuteDeleteAsync();
            return incentivosTecnicos > 0;
        }

        public async Task<IncentivosTecnicos?> Buscar(int IncentivoId)
        {
            return await _context.IncentivosTecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.IncentivoId == IncentivoId);
        }

        public async Task<List<IncentivosTecnicos>> Listar(Expression<Func<IncentivosTecnicos, bool>> criterio)
        {
            return await _context.IncentivosTecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
