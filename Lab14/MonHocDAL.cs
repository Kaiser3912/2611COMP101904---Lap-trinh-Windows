using Lab14.Data;
using Lab14.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab14.DAL
{
    public class MonHocDAL
    {
        public List<MonHoc> GetAll()
        {
            using (var context = new Lab14Context())
            {
                return context.MonHocs.ToList();
            }
        }

        public MonHoc GetById(string maMonHoc)
        {
            using (var context = new Lab14Context())
            {
                return context.MonHocs.FirstOrDefault(m => m.MaMonHoc == maMonHoc);
            }
        }

        public bool Insert(MonHoc monHoc)
        {
            using (var context = new Lab14Context())
            {
                context.MonHocs.Add(monHoc);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(MonHoc monHoc)
        {
            using (var context = new Lab14Context())
            {
                var existing = context.MonHocs.FirstOrDefault(m => m.MaMonHoc == monHoc.MaMonHoc);
                if (existing != null)
                {
                    existing.TenMonHoc = monHoc.TenMonHoc;
                    existing.SoTinChi = monHoc.SoTinChi;
                    existing.TrangThai = monHoc.TrangThai;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        public bool Delete(string maMonHoc)
        {
            using (var context = new Lab14Context())
            {
                var monHoc = context.MonHocs.FirstOrDefault(m => m.MaMonHoc == maMonHoc);
                if (monHoc != null)
                {
                    context.MonHocs.Remove(monHoc);
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        public List<MonHoc> Search(string keyword)
        {
            using (var context = new Lab14Context())
            {
                return context.MonHocs
                    .Where(m => m.MaMonHoc.Contains(keyword) || m.TenMonHoc.Contains(keyword))
                    .ToList();
            }
        }
    }
}