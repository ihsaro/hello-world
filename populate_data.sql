INSERT INTO Candidates (FirstName, LastName, EmailAddress, LinkedInURL, CandidateType, CandidateLocation, YearsOfExperience, CreatedTimestamp, LastUpdatedTimestamp)
VALUES
('John', 'Stones', 'idjazhossanee@gmail.com', '', 0, 'Mauritius', 2, DATE('now'), DATE('now')),
('Michael', 'Park', 'idjazhossanee@gmail.com', '', 1, 'Poland', 1, DATE('now'), DATE('now')),
('Oliver', 'Hart', 'idjazhossanee@gmail.com', '', 2, 'England', 9, DATE('now'), DATE('now')),
('Sarah', 'Rodriguez', 'idjazhossanee@gmail.com', '', 0, 'England', 8, DATE('now'), DATE('now')),
('Kate', 'Modesty', 'idjazhossanee@gmail.com', '', 1, 'Mauritius', 12, DATE('now'), DATE('now')),
('Kim', 'San', 'idjazhossanee@gmail.com', '', 2, 'Mauritius', 10, DATE('now'), DATE('now')),
('Hannah', 'Bullet', 'idjazhossanee@gmail.com', '', 0, 'Poland', 4, DATE('now'), DATE('now')),
('James', 'Middleschool', 'idjazhossanee@gmail.com', '', 1, 'Germany', 6, DATE('now'), DATE('now')),
('Richard', 'Milestone', 'idjazhossanee@gmail.com', '', 2, 'Poland', 5, DATE('now'), DATE('now')),
('Gabriel', 'Rock', 'idjazhossanee@gmail.com', '', 0, 'Poland', 3, DATE('now'), DATE('now'));

INSERT INTO CandidateSkills (CandidateId, Skill, CreatedTimestamp, LastUpdatedTimestamp)
VALUES
(1, 'Java', DATE('now'), DATE('now')),
(1, 'C#', DATE('now'), DATE('now')),
(2, 'Java', DATE('now'), DATE('now')),
(2, 'C#', DATE('now'), DATE('now')),
(2, 'Python', DATE('now'), DATE('now')),
(3, 'C#', DATE('now'), DATE('now')),
(3, 'React', DATE('now'), DATE('now')),
(3, 'Effective Communication', DATE('now'), DATE('now')),
(3, 'Agile Planning', DATE('now'), DATE('now'));

INSERT INTO JobPostings (Title, Description, YearsOfExperience, JobLocation, JobType, JobStatus, CreatedTimestamp, LastUpdatedTimestamp)
VALUES
('Associate Software Engineer', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('Software Engineer', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('Senior Software Engineer', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('Technical Architect', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('Test Automation Engineer', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('QA Engineer', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('QA Senior Engineer', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('QA Lead Engineer', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('Director in Technology', '', 2, 0, 0, 0, DATE('now'), DATE('now')),
('HR Manager', '', 2, 0, 0, 0, DATE('now'), DATE('now'));

INSERT INTO JobSkills (Name, Description, SkillCategory, CreatedTimestamp, LastUpdatedTimestamp)
VALUES
('C#', '', 1, DATE('now'), DATE('now')),
('Java', '', 1, DATE('now'), DATE('now')),
('Python', '', 1, DATE('now'), DATE('now')),
('Angular', '', 1, DATE('now'), DATE('now')),
('React', '', 1, DATE('now'), DATE('now')),
('Vue', '', 1, DATE('now'), DATE('now')),
('Svelte', '', 1, DATE('now'), DATE('now')),
('Effective Communication', '', 0, DATE('now'), DATE('now')),
('Effective Mentoring', '', 3, DATE('now'), DATE('now')),
('Agile Planning', '', 2, DATE('now'), DATE('now'));

INSERT INTO JobPostingSkills(JobPostingId, JobSkillId, CreatedTimestamp, LastUpdatedTimestamp)
VALUES
(1, 1, DATE('now'), DATE('now')),
(1, 3, DATE('now'), DATE('now')),
(1, 4, DATE('now'), DATE('now')),
(2, 2, DATE('now'), DATE('now')),
(2, 5, DATE('now'), DATE('now')),
(10, 8, DATE('now'), DATE('now')),
(10, 9, DATE('now'), DATE('now')),
(6, 1, DATE('now'), DATE('now')),
(6, 2, DATE('now'), DATE('now')),
(6, 8, DATE('now'), DATE('now'));