using AcademiaBaile.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class ACADEMIAContext : DbContext
{
    public ACADEMIAContext(DbContextOptions<ACADEMIAContext> options)
        : base(options)
    {
    }

    public DbSet<estudiantes> Estudiantes { get; set; }
    public DbSet<instructores> Instructores { get; set; }
    public DbSet<clases> Clases { get; set; }
    public DbSet<inscripciones> Inscripciones { get; set; }
    public DbSet<pagos> Pagos { get; set; }
    public DbSet<ritmos> Ritmos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<estudiantes>().HasData(
            new estudiantes { Id = 1, Nombre = "Juan", Apellido = "Pérez", FechaNacimiento = new DateTime(1995, 5, 23), Email = "juan.perez@example.com", Telefono = "123456789" },
            new estudiantes { Id = 2, Nombre = "Ana", Apellido = "Gómez", FechaNacimiento = new DateTime(1998, 8, 15), Email = "ana.gomez@example.com", Telefono = "987654321" }
        );

        modelBuilder.Entity<instructores>().HasData(
            new instructores { Id = 1, Nombre = "Carlos", Apellido = "López", Especialidad = "Salsa", Email = "carlos.lopez@example.com", Telefono = "555123456" },
            new instructores { Id = 2, Nombre = "María", Apellido = "Rodríguez", Especialidad = "Bachata", Email = "maria.rodriguez@example.com", Telefono = "555654321" }
        );

        modelBuilder.Entity<ritmos>().HasData(
            new ritmos { Id = 1, Nombre = "Salsa", Descripcion = "Un ritmo latino popular" },
            new ritmos { Id = 2, Nombre = "Bachata", Descripcion = "Un ritmo romántico y sensual" }
        );

        modelBuilder.Entity<clases>().HasData(
            new clases { Id = 1, Nombre = "Clase de Salsa", Descripcion = "Aprende los pasos básicos de salsa", InstructorId = 1, Horario = "Lunes y Miércoles 18:00-19:00", RitmoId = 1 },
            new clases { Id = 2, Nombre = "Clase de Bachata", Descripcion = "Aprende los pasos básicos de bachata", InstructorId = 2, Horario = "Martes y Jueves 19:00-20:00", RitmoId = 2 }
        );

        modelBuilder.Entity<inscripciones>().HasData(
            new inscripciones { Id = 1, EstudianteId = 1, ClaseId = 1, FechaInscripcion = DateTime.Now },
            new inscripciones { Id = 2, EstudianteId = 2, ClaseId = 2, FechaInscripcion = DateTime.Now }
        );

        modelBuilder.Entity<pagos>().HasData(
            new pagos { Id = 1, EstudianteId = 1, Monto = 50.00m, FechaPago = DateTime.Now, MetodoPago = "Tarjeta de Crédito" },
            new pagos { Id = 2, EstudianteId = 2, Monto = 50.00m, FechaPago = DateTime.Now, MetodoPago = "Efectivo" }
        );
    }
}
