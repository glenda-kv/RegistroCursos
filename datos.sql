-- CREACION DE TABLAS


CREATE TABLE "Facultades"
(
    "IdFacultad" SERIAL PRIMARY KEY,
    "CodigoFacultad" VARCHAR(10) NOT NULL UNIQUE,
    "Nombre" VARCHAR(100) NOT NULL,
    "Decano" VARCHAR(100) NOT NULL,
    "Ubicacion" VARCHAR(150) NOT NULL
);



CREATE TABLE "Carreras"
(
    "IdCarrera" SERIAL PRIMARY KEY,
    "CodigoCarrera" VARCHAR(10) NOT NULL UNIQUE,
    "Nombre" VARCHAR(100) NOT NULL,
    "DuracionAnios" INT NOT NULL CHECK("DuracionAnios" BETWEEN 1 AND 10),
    "Modalidad" VARCHAR(20) NOT NULL,

    "IdFacultad" INT NOT NULL,

    CONSTRAINT "FK_Carrera_Facultad"
    FOREIGN KEY("IdFacultad")
    REFERENCES "Facultades"("IdFacultad")
);



CREATE TABLE "Estudiantes"
(
    "IdEstudiante" SERIAL PRIMARY KEY,
    "NumeroMatricula" VARCHAR(15) NOT NULL UNIQUE,
    "Nombre" VARCHAR(50) NOT NULL,
    "Apellido" VARCHAR(50) NOT NULL,
    "Correo" VARCHAR(100) NOT NULL UNIQUE,
    "Telefono" VARCHAR(15),
    "FechaNacimiento" DATE NOT NULL,

    "IdCarrera" INT NOT NULL,

    CONSTRAINT "FK_Estudiante_Carrera"
    FOREIGN KEY("IdCarrera")
    REFERENCES "Carreras"("IdCarrera")
);



CREATE TABLE "Docentes"
(
    "IdDocente" SERIAL PRIMARY KEY,
    "Cedula" VARCHAR(20) NOT NULL UNIQUE,
    "Nombre" VARCHAR(50) NOT NULL,
    "Apellido" VARCHAR(50) NOT NULL,
    "Especialidad" VARCHAR(100) NOT NULL,
    "Correo" VARCHAR(100) NOT NULL UNIQUE,
    "Telefono" VARCHAR(15)
);



CREATE TABLE "Cursos"
(
    "IdCurso" SERIAL PRIMARY KEY,
    "CodigoCurso" VARCHAR(10) NOT NULL UNIQUE,
    "Nombre" VARCHAR(100) NOT NULL,
    "Creditos" INT NOT NULL CHECK("Creditos" BETWEEN 1 AND 20),
    "FechaInicio" DATE NOT NULL,
    "FechaFin" DATE NOT NULL,

    "IdDocente" INT NOT NULL,

    CONSTRAINT "FK_Curso_Docente"
    FOREIGN KEY("IdDocente")
    REFERENCES "Docentes"("IdDocente")
);



CREATE TABLE "Inscripciones"
(
    "IdInscripcion" SERIAL PRIMARY KEY,

    "IdEstudiante" INT NOT NULL,
    "IdCurso" INT NOT NULL,

    "FechaInscripcion" DATE NOT NULL,
    "Estado" VARCHAR(20) NOT NULL,
    "NotaFinal" DECIMAL(5,2)
        CHECK("NotaFinal" BETWEEN 0 AND 100),


    CONSTRAINT "FK_Inscripcion_Estudiante"
    FOREIGN KEY("IdEstudiante")
    REFERENCES "Estudiantes"("IdEstudiante"),


    CONSTRAINT "FK_Inscripcion_Curso"
    FOREIGN KEY("IdCurso")
    REFERENCES "Cursos"("IdCurso"),


    CONSTRAINT "UQ_Estudiante_Curso"
    UNIQUE("IdEstudiante","IdCurso")
);



-- DATOS DE PRUEBA


INSERT INTO "Facultades"
("CodigoFacultad","Nombre","Decano","Ubicacion")
VALUES

('FAC001','Ingenieria','Carlos Rojas','Bloque A'),
('FAC002','Economia','Maria Lopez','Bloque B'),
('FAC003','Derecho','Juan Perez','Bloque C'),
('FAC004','Medicina','Ana Torres','Bloque D'),
('FAC005','Arquitectura','Luis Flores','Bloque E');

INSERT INTO "Carreras"
("CodigoCarrera","Nombre","DuracionAnios","Modalidad","IdFacultad")
VALUES

('CAR001','Ingenieria de Sistemas',5,'Presencial',1),
('CAR002','Administracion de Empresas',5,'Mixta',2),
('CAR003','Derecho',5,'Presencial',3),
('CAR004','Medicina General',6,'Presencial',4),
('CAR005','Arquitectura',5,'Virtual',5);

INSERT INTO "Docentes"
("Cedula","Nombre","Apellido","Especialidad","Correo","Telefono")
VALUES

('111111','Pedro','Mamani','Base de Datos','pedro@gmail.com','70000001'),
('222222','Laura','Quispe','Programacion','laura@gmail.com','70000002'),
('333333','Carlos','Flores','Redes','carlos@gmail.com','70000003'),
('444444','Ana','Vargas','Matematicas','ana@gmail.com','70000004'),
('555555','Luis','Condori','Software','luis@gmail.com','70000005');


INSERT INTO "Estudiantes"
("NumeroMatricula","Nombre","Apellido","Correo","Telefono","FechaNacimiento","IdCarrera")
VALUES

('2026001','Juan','Perez','juan@gmail.com','71000001','2000-01-10',1),
('2026002','Maria','Lopez','maria@gmail.com','71000002','2001-02-15',1),
('2026003','Carlos','Mamani','carlos@gmail.com','71000003','2000-03-20',2),
('2026004','Sofia','Quispe','sofia@gmail.com','71000004','2002-04-25',3),
('2026005','Diego','Flores','diego@gmail.com','71000005','2001-05-30',5);

INSERT INTO "Cursos"
("CodigoCurso","Nombre","Creditos","FechaInicio","FechaFin","IdDocente")
VALUES

('CUR001','Base de Datos',5,'2026-03-01','2026-07-01',1),
('CUR002','Programacion Web',4,'2026-03-01','2026-07-01',2),
('CUR003','Redes',4,'2026-03-01','2026-07-01',3),
('CUR004','Matematicas',3,'2026-03-01','2026-07-01',4),
('CUR005','Arquitectura Software',5,'2026-03-01','2026-07-01',5);


INSERT INTO "Inscripciones"
("IdEstudiante","IdCurso","FechaInscripcion","Estado","NotaFinal")
VALUES

(1,1,'2026-03-05','Activo',85),
(2,1,'2026-03-05','Activo',90),
(3,2,'2026-03-06','Activo',75),
(4,3,'2026-03-06','Activo',88),
(5,5,'2026-03-07','Activo',92);



