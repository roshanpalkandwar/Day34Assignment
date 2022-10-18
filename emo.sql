CREATE DATABASE Employee_Payroll_Service1

USE Employee_Payroll_Service1

CREATE TABLE Employee_Payroll
(
	EmployeeID int primary key identity,
	EmployeeName varchar(255),
	PhoneNumber bigint,
	Address varchar(255),
	Department varchar(200),
	Gender char(1),
	BasicPay float,
	Deduction float,
	TaxablePay float,
	Tax float,
	NetPay float,
	City varchar(100),
	Country varchar(100)
)

SELECT * FROM Employee_Payroll

CREATE PROCEDURE SpAddEmployeedetails
(
	@EmployeeName varchar(255),
    @PhoneNumber bigint,
    @Address varchar(200),
    @Department varchar(200),
    @Gender char(1),
    @BasicPay float,
    @Deduction float,
    @TaxablePay float,
    @Tax float,
    @NetPay float,
    @City varchar(100),
    @Country varchar(100)
)
as
begin
	insert into Employee_Payroll(EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deduction,TaxablePay,
	Tax,NetPay,City,Country)
	VALUES(@EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@BasicPay,@Deduction,@TaxablePay,@Tax,
	@NetPay,@City,@Country)
end

DROP TABLE Employee_Payroll
DROP PROCEDURE SpAddEmployeedetails

CREATE TABLE Salary
(
	SalaryID int primary key identity,
	EmployeeID int,
	EmployeeName varchar(255),
	JobDescription varchar(200),
	Month varchar(10),
	EmployeeSalary int
)

SELECT * FROM Salary

INSERT INTO Salary VALUES (1,'Bruce','HR','Jan',12000)
INSERT INTO Salary VALUES (2,'Riya','Sales','May',15000)
INSERT INTO Salary VALUES (3,'terisa','Management','June',10000)