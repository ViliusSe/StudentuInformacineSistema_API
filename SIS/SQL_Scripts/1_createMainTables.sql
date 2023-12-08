CREATE TABLE departments (
    id SERIAL PRIMARY KEY,
    name VARCHAR NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE lectures (
    id SERIAL PRIMARY KEY,
    name VARCHAR NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE students (
    id SERIAL PRIMARY KEY,
    name VARCHAR NOT NULL,
    departments_id INTEGER REFERENCES departments(id) ON DELETE SET NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE departments_lectures (
    id SERIAL PRIMARY KEY,
    departments_id INTEGER REFERENCES departments(id) ON DELETE CASCADE,
    lectures_id INTEGER REFERENCES lectures(id) ON DELETE CASCADE
);

CREATE TABLE students_lectures (
    id SERIAL PRIMARY KEY,
    students_id INTEGER REFERENCES students(id) ON DELETE CASCADE,
    lectures_id INTEGER REFERENCES lectures(id) ON DELETE CASCADE
);