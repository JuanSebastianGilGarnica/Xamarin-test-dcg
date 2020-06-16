namespace TestDCG.Cross.Entities.Reference
{
    using System;
    using System.Collections.Generic;
    using TestDCG.Cross.Entities.Data;

    public class DeptComparer : IEqualityComparer<DepartmetData>
    {
        public bool Equals(DepartmetData x, DepartmetData y)
        {
            if (x is null || y is null)
            {
                return false;
            }
            if (string.Equals(x.DaneCodeDept.ToString(), y.DaneCodeDept.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(DepartmetData obj)
        {
            return obj is null || obj.Department is null ? 0 : obj.Department.GetHashCode();
        }
    }
}
