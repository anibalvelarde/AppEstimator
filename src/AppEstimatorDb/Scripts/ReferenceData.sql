/***************
	Reference Data for Complexity Entity...
**/
if not exists(select * from dbo.Complexity where [Type] = 'A' and Name = 'Simple')
	insert into dbo.Complexity([Type], Name, Value) values('A','Simple', 1);
if not exists(select * from dbo.Complexity where [Type] = 'A' and Name = 'Average')
	insert into dbo.Complexity([Type], Name, Value) values('A','Average', 2);
if not exists(select * from dbo.Complexity where [Type] = 'A' and Name = 'Complex')
	insert into dbo.Complexity([Type], Name, Value) values('A','Complex', 3);
if not exists(select * from dbo.Complexity where [Type] = 'U' and Name = 'Simple')
	insert into dbo.Complexity([Type], Name, Value) values('U','Simple', 5);
if not exists(select * from dbo.Complexity where [Type] = 'U' and Name = 'Average')
	insert into dbo.Complexity([Type], Name, Value) values('U','Average', 10);
if not exists(select * from dbo.Complexity where [Type] = 'U' and Name = 'Complex')
	insert into dbo.Complexity([Type], Name, Value) values('U','Complex', 15);
/***************
	Reference Data for Environmental Factors...
**/
if not exists(select * from dbo.EnvironmentalFactor where Name = 'Familiarity with the Project')
	insert into dbo.EnvironmentalFactor(Name, Description, Multiplier) values('Familiarity with the Project','How much experience does your team have working in this domain? The domain of the project will be a reflection of what the software is intended to accomplish, not the implementation language. In other words, for an insurance compensation system written in java, you care about the team’s experience in the insurance compensation space - not how much java they’ve written. Higher levels of experience get a higher number.', 1.5);
if not exists(select * from dbo.EnvironmentalFactor where Name = 'Application Experience')
	insert into dbo.EnvironmentalFactor(Name, Description, Multiplier) values('Application Experience','How much experience does your team have with the application. This will only be relevant when making changes to an existing application. Higher numbers represent more experience. For a new application, everyone’s experience will be 0.', 0.5);
if not exists(select * from dbo.EnvironmentalFactor where Name = 'OO Programming Experience')
	insert into dbo.EnvironmentalFactor(Name, Description, Multiplier) values('OO Programming Experience','How much experience does your team have at OO? It can be easy to forget that many people have no object oriented programming experience if you are used to having it. A user-centric or use-case-driven project will have an inherently OO structure in the implementation. Higher numbers represent more OO experience.', 1);
if not exists(select * from dbo.EnvironmentalFactor where Name = 'Lead Analyst Capability')
	insert into dbo.EnvironmentalFactor(Name, Description, Multiplier) values('Lead Analyst Capability','How knowledgeable and capable is the person responsible for the requirements? Bad requirements are the number one killer of projects - the Standish Group reports that 40% to 60% of defects come from bad requirements. Higher numbers represent increased skill and knowledge.', 0.5);
if not exists(select * from dbo.EnvironmentalFactor where Name = 'Motivation')
	insert into dbo.EnvironmentalFactor(Name, Description, Multiplier) values('Motivation','How motivated is your team? Higher numbers represent more motivation.', 1);
if not exists(select * from dbo.EnvironmentalFactor where Name = 'Stable Requirements')
	insert into dbo.EnvironmentalFactor(Name, Description, Multiplier) values('Stable Requirements','Changes in requirements can cause increases in work. The way to avoid this is by planning for change and instituting a timing system for managing those changes. Most people don’t do this, and some rework will be unavoidable. Higher numbers represent more change (or a less effective system for managing change).', 2);
if not exists(select * from dbo.EnvironmentalFactor where Name = 'Part-Time Staff')
	insert into dbo.EnvironmentalFactor(Name, Description, Multiplier) values('Part-Time Staff','Note, the multiplier for this number is negative. Higher numbers reflect team members that are part time, outside consultants, and developers who are splitting their time across projects. Context switching and other intangible factors make these team members less efficient.', -1);
if not exists(select * from dbo.EnvironmentalFactor where Name = 'Difficult Programming Language')
	insert into dbo.EnvironmentalFactor(Name, Description, Multiplier) values('Difficult Programming Language','This multiplier is also negative. Harder languages represent higher numbers. We believe that difficulty is in the eye of the be-coder (groan). Java might be difficult for a fortran programmer. Think of it in terms of difficulty for your team, not abstract difficulty.', -1);
/***************
	Reference Data for Technical Factors...
**/
if not exists(select * from dbo.TechnicalFactor where Name = 'Distributed System Required')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Distributed System Required','The architecture of the solution may be centralized or single-tenant , or it may be distributed (like an n-tier solution) or multi-tenant. Higher numbers represent a more complex architecture.', 2);
if not exists(select * from dbo.TechnicalFactor where Name = 'Response Time is important')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Response Time is important','The quickness of response for users is an important (and non-trivial) factor. For example, if the server load is expected to be very low, this may be a trivial factor. Higher numbers represent increasing importance of response time (a search engine would have a high number, a daily news aggregator would have a low number).', 1);
if not exists(select * from dbo.TechnicalFactor where Name = 'End User Efficency')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('End User Efficiency','Is the application being developed to optimize on user efficiency, or just capability? Higher numbers represent projects that rely more heavily on the application to improve user efficiency.', 1);
if not exists(select * from dbo.TechnicalFactor where Name = 'Complex Internal Processing is required')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Complex Internal Processing is required','Is there a lot of difficult algorithmic work to do and test? Complex algorithms (resource leveling, time-domain systems analysis, OLAP cubes) have higher numbers. Simple database queries would have low numbers.', 1);
if not exists(select * from dbo.TechnicalFactor where Name = 'Reusable code must be a focus')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Reusable code must be a focus','Is heavy code reuse an objective or goal? Code reuse reduces the amount of effort required to deploy a project. It also reduces the amount of time required to debug a project. A shared library function can be re-used multiple times, and fixing the code in one place can resolve multiple bugs. The higher the level of re-use, the lower the number.', 1);
if not exists(select * from dbo.TechnicalFactor where Name = 'Installation Ease')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Installation Ease','Is ease of installation for end users a key factor? The higher the level of competence of the users, the lower the number.', 0.5);
if not exists(select * from dbo.TechnicalFactor where Name = 'Usability')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Usability','Is ease of use a primary criteria for acceptance? The greater the importance of usability, the higher the number.', 0.5);
if not exists(select * from dbo.TechnicalFactor where Name = 'Cross-Platform Support')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Clross-Platform Support','Is multi-platform support required? The more platforms that have to be supported (this could be browser versions, mobile devices, etc. or Windows/OSX/Unix), the higher the value.', 2);
if not exists(select * from dbo.TechnicalFactor where Name = 'Easy to Change')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Easy to Change','Does the customer require the ability to change or customize the application in the future? The more change / customization that is required in the future, the higher the value.', 1);
if not exists(select * from dbo.TechnicalFactor where Name = 'Highly concurrent')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Highly concurrent','Will you have to address database locking and other concurrency issues? The more attention you have to spend to resolving conflicts in the data or application, the higher the value.', 1);
if not exists(select * from dbo.TechnicalFactor where Name = 'Custom Security')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Custom Security','Can existing security solutions be leveraged, or must custom code be developed? The more custom security work you have to do (field level, page level, or role based security, for example), the higher the value.', 1);
if not exists(select * from dbo.TechnicalFactor where Name = 'Dependence on Third-Party code')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('Dependence on Third-Party code','Will the application require the use of third party controls or libraries? Like re-usable code, third party code can reduce the effort required to deploy a solution. The more third party code (and the more reliable the third party code), the lower the number.', 1);
if not exists(select * from dbo.TechnicalFactor where Name = 'User Training')
	insert into dbo.TechnicalFactor(Name, Description, Multiplier) values('User Training','How much user training is required? Is the application complex, or supporting complex activities? The longer it takes users to cross the suck threshold (achieve a level of mastery of the product), the higher the value.', 1);