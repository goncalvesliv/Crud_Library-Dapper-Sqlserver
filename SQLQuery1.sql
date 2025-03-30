create table books (
	
	Id int IDENTITY (1,1),
	Title varchar(100),
	Author varchar (100),
	Year decimal,
	Available bit
)

select * from books

use Crud_Library