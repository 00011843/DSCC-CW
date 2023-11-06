-- Insert data into the Company table
INSERT INTO Company (Name, Description, Contact)
VALUES
    ('TechCo', 'A technology company specializing in software development.', 'contact@techco.com'),
    ('Green Solutions', 'An environmental consulting firm.', 'info@greensolutions.com'),
    ('HealthCare Inc', 'A healthcare services provider.', 'hr@healthcareinc.com'),
    ('DataTech', 'A data analytics company.', 'info@datatech.com'),
    ('Marketing Pro', 'A marketing and advertising agency.', 'info@marketingpro.com');
GO

-- Insert vacancies for each company
DECLARE @CompanyId INT;

-- Insert vacancies for TechCo
SET @CompanyId = (SELECT Id FROM Company WHERE Name = 'TechCo');
INSERT INTO Vacancy (JobName, CompanyId, JobDescription, JobOpenedDate, JobClosedDate, Salary)
VALUES
    ('Software Engineer', @CompanyId, 'We are looking for a skilled software engineer to join our team.', '2023-01-15', '2023-02-15', 75000.00),
    ('Data Analyst', @CompanyId, 'TechCo is hiring a data analyst to analyze big data.', '2023-03-01', '2023-04-01', 70000.00),
    ('DevOps Engineer', @CompanyId, 'TechCo is seeking a DevOps engineer to optimize our development process.', '2023-02-15', '2023-03-15', 80000.00),
    ('Frontend Developer', @CompanyId, 'We are looking for a frontend developer to create amazing user interfaces.', '2023-02-01', '2023-03-01', 72000.00),
    ('Database Administrator', @CompanyId, 'Join us as a database administrator to manage our data systems.', '2023-03-15', '2023-04-15', 78000.00),
    ('Quality Assurance Engineer', @CompanyId, 'TechCo is hiring a QA engineer to ensure software quality.', '2023-04-01', '2023-05-01', 70000.00);

-- Insert vacancies for Green Solutions
SET @CompanyId = (SELECT Id FROM Company WHERE Name = 'Green Solutions');
INSERT INTO Vacancy (JobName, CompanyId, JobDescription, JobOpenedDate, JobClosedDate, Salary)
VALUES
    ('Environmental Consultant', @CompanyId, 'Join our team as an environmental consultant and make a difference!', '2023-02-01', '2023-03-01', 60000.00),
    ('Environmental Scientist', @CompanyId, 'Green Solutions is seeking an environmental scientist for research projects.', '2023-02-15', '2023-03-15', 65000.00),
    ('GIS Analyst', @CompanyId, 'We have an opening for a Geographic Information Systems (GIS) analyst.', '2023-03-01', '2023-04-01', 62000.00),
    ('Environmental Engineer', @CompanyId, 'Join our team as an environmental engineer to work on sustainability projects.', '2023-01-15', '2023-02-15', 68000.00),
    ('Sustainability Coordinator', @CompanyId, 'Green Solutions is hiring a sustainability coordinator to manage eco-friendly projects.', '2023-02-15', '2023-03-15', 65000.00),
    ('Ecologist', @CompanyId, 'Join us as an ecologist to conduct field studies and ecological assessments.', '2023-03-01', '2023-04-01', 60000.00);

-- Insert vacancies for HealthCare Inc
SET @CompanyId = (SELECT Id FROM Company WHERE Name = 'HealthCare Inc');
INSERT INTO Vacancy (JobName, CompanyId, JobDescription, JobOpenedDate, JobClosedDate, Salary)
VALUES
    ('Nurse Practitioner', @CompanyId, 'We have a vacancy for a nurse practitioner in our healthcare team.', '2023-01-01', '2023-02-01', 90000.00),
    ('Medical Doctor', @CompanyId, 'HealthCare Inc is looking for a medical doctor to join our team.', '2023-02-15', '2023-03-15', 110000.00),
    ('Registered Nurse', @CompanyId, 'Join us as a registered nurse and provide quality care.', '2023-03-01', '2023-04-01', 75000.00),
    ('Pharmacist', @CompanyId, 'We are hiring a pharmacist for our healthcare services.', '2023-01-15', '2023-02-15', 80000.00),
    ('Physical Therapist', @CompanyId, 'HealthCare Inc is seeking a physical therapist to help patients regain mobility.', '2023-02-15', '2023-03-15', 75000.00),
    ('Dental Hygienist', @CompanyId, 'Join us as a dental hygienist to promote oral health.', '2023-03-01', '2023-04-01', 60000.00);

-- Insert vacancies for DataTech
SET @CompanyId = (SELECT Id FROM Company WHERE Name = 'DataTech');
INSERT INTO Vacancy (JobName, CompanyId, JobDescription, JobOpenedDate, JobClosedDate, Salary)
VALUES
    ('Data Scientist', @CompanyId, 'DataTech is hiring a data scientist for cutting-edge data analysis.', '2023-01-15', '2023-02-15', 85000.00),
    ('Machine Learning Engineer', @CompanyId, 'Join us as a machine learning engineer to work on AI projects.', '2023-02-01', '2023-03-01', 90000.00),
    ('Database Administrator', @CompanyId, 'DataTech is seeking a database administrator to manage our data systems.', '2023-03-15', '2023-04-15', 75000.00),
    ('Data Analyst', @CompanyId, 'Join DataTech as a data analyst to analyze market trends and business data.', '2023-02-15', '2023-03-15', 72000.00),
    ('Big Data Engineer', @CompanyId, 'We are looking for a big data engineer to work on large-scale data projects.', '2023-04-01', '2023-05-01', 80000.00),
    ('Data Visualization Specialist', @CompanyId, 'DataTech is hiring a data visualization specialist to create informative data visuals.', '2023-05-15', '2023-06-15', 72000.00);

-- Insert vacancies for Marketing Pro
SET @CompanyId = (SELECT Id FROM Company WHERE Name = 'Marketing Pro');
INSERT INTO Vacancy (JobName, CompanyId, JobDescription, JobOpenedDate, JobClosedDate, Salary)
VALUES
    ('Marketing Manager', @CompanyId, 'Marketing Pro is looking for a marketing manager to lead our campaigns.', '2023-01-15', '2023-02-15', 80000.00),
    ('Digital Marketing Specialist', @CompanyId, 'Join us as a digital marketing specialist and boost our online presence.', '2023-02-01', '2023-03-01', 65000.00),
    ('Content Writer', @CompanyId, 'We have an opening for a creative content writer to craft compelling content.', '2023-03-01', '2023-04-01', 60000.00),
    ('Graphic Designer', @CompanyId, 'Marketing Pro is seeking a talented graphic designer for visual content creation.', '2023-02-15', '2023-03-15', 68000.00),
    ('Social Media Manager', @CompanyId, 'Join us as a social media manager to handle our online presence and campaigns.', '2023-04-01', '2023-05-01', 70000.00),
    ('SEO Specialist', @CompanyId, 'Marketing Pro is hiring an SEO specialist to improve search engine rankings.', '2023-05-15', '2023-06-15', 65000.00);
GO
