namespace MCC_C__Code
{


    public class LINQ
    {
        public void Menu()
        {
            Console.WriteLine("Pilih Menu");
            Console.WriteLine("1. Soal 1");
            Console.WriteLine("2. Soal 2");
            Console.WriteLine("3. Back To Main Menu");
            Console.WriteLine("Pilih: ");
            int input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    GetAllEmployeeData();
                    break;
                case 2:
                    CountEmployeeEachDepartment();
                    break;
                case 3:
                    break;

            }
        }

        public void GetAllEmployeeData()
        {
            //    Buatlah** Method LINQ** untuk menampilkan data dengan kriteria yang ditampilkan
            //1. Data employee
            //2. Tambahkan informasi nama department
            //3. Tambahkan informasi lokasi
            //4. Tambahkan informasi country
            //5. Tambahkan informasi region
            //6. Limit data yang tampil hanya 5
            //column yang tampil : id, full_name, email, phone, salary, department_name, street_address, country_name, region_name.

            Console.Clear();
            var employee = new employees();
            var department = new departments();
            var location = new locations();
            var country = new Countries();
            var region = new Region();

            var employees = (from e in employee.GetAllEmployees()
                             join d in department.GetAllDepartments() on e.department_id equals d.id
                             join l in location.GetAllLocations() on d.location_id equals l.id
                             join c in country.GetAllCountries() on l.country_id equals c.id
                             join r in region.GetAllRegion() on c.region_id equals r.Id
                             select new
                             {
                                 ID = e.id,
                                 FirstName = e.first_name,
                                 Email = e.email,
                                 Phone = e.phone_number,
                                 Salary = e.salary,
                                 DepartmentName = d.name,
                                 StreetAddress = l.street_address,
                                 CountryName = c.nama,
                                 RegionName = r.Name
                             }).Take(5);

            foreach (var emp in employees)
            {
                Console.WriteLine("=====================================================================================================================================================================");
                Console.WriteLine($"ID:{emp.ID} || {emp.FirstName} || {emp.Email} || {emp.Phone} " +
                    $"{emp.Salary} || {emp.DepartmentName} || {emp.StreetAddress} " +
                    $" || {emp.CountryName} || {emp.RegionName}");
                Console.WriteLine("=====================================================================================================================================================================");
            }

        }

        public void CountEmployeeEachDepartment()
        {
            //Buatlah** Method LINQ** untuk menampilkan data dengan kriteria yang ditampilkan
            //1.Jumlah employeee pada tiap department
            //2.gaji terkecil, gaji terbesar, gaji rata rata pada tiap department
            //3.tampilkan data yang hanya jumlah employee lebih dari 3
            //column yang tampil: department_name, total_employee, min_salary, max_salary, average_salary

            Console.Clear();
            var employee = new employees();
            var department = new departments();


            var empDepartment = (from d in department.GetAllDepartments()
                                 join e in employee.GetAllEmployees() on d.id equals e.department_id into empDpt
                                 where empDpt.Count() > 3
                                 select new
                                 {
                                     DepartmentName = d.name,
                                     TotalEmployee = empDpt.Count(),
                                     MinSalary = empDpt.Min(e => e.salary),
                                     MaxSalary = empDpt.Max(e => e.salary),
                                     AverageSalary = empDpt.Average(e => e.salary),

                                 });

            foreach (var empDpt in empDepartment)
            {
                Console.WriteLine("===================================================================================================================");
                Console.WriteLine($"{empDpt.DepartmentName} || Total Employees: {empDpt.TotalEmployee} || Min Salary: {empDpt.MinSalary} || Max Salary: {empDpt.MaxSalary} || Average Salary: {empDpt.AverageSalary}");
                Console.WriteLine("===================================================================================================================");
            }

        }

    }
}
