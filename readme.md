## Задание 1

Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:

 - Юнит-тесты
 - Легкость добавления других фигур
 - Вычисление площади фигуры без знания типа фигуры в compile-time
 - Проверку на то, является ли треугольник прямоугольным

## Задание 2

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

```tsql

CREATE TABLE Products
(
    Id int identity not null primary key,
    Name varchar(255)
);

INSERT INTO Products VALUES
    ('Product #1'), ('Product #2'),
    ('Product #3'), ('Product #4');

CREATE TABLE Categories
(
    Id int identity not null primary key,
    Name varchar(255)
);

INSERT INTO Categories VALUES
    ('Category #1'), ('Category #2');

CREATE TABLE ProductsInCategories
(
    ProductId  int,
    CategoryId int,

    CONSTRAINT PK_ProductsInCategories PRIMARY KEY (ProductId, CategoryId),
    CONSTRAINT FK_ProductId FOREIGN KEY (ProductId) REFERENCES Products (Id),
    CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories (Id)
);

INSERT INTO ProductsInCategories VALUES
    (1, 1), (1, 2),
    (2, 1), (3, 2);

-----------------------------------------------------------------------------------------------

SELECT c.Name, p.Name FROM Products p
LEFT JOIN ProductsInCategories pic ON p.Id = pic.ProductId
LEFT JOIN Categories c ON c.Id = pic.CategoryId
ORDER BY c.Id, p.Id;

```