-- SQLite
/*
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
*/

INSERT INTO CandidateSkills (CandidateId, Skill, CreatedTimestamp, LastUpdatedTimestamp)
VALUES
(1, 'Java', DATE('now'), DATE('now')),
(1, 'C#', DATE('now'), DATE('now')),
(2, 'Java', DATE('now'), DATE('now')),
(2, 'C#', DATE('now'), DATE('now')),
(2, 'Python', DATE('now'), DATE('now'));