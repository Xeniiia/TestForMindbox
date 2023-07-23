### Задание по SQL:

В данном задании описана связь многие-ко-многим между таблицами продуктов и категорий. Для реализации такой связи необходимо создать третью таблицу, которая будет связывать продукты с их категориями.
Предположим, что у нас есть две таблицы: "Products" (с колонками "ProductID", "ProductName") и "Categories" (с колонками "CategoryID" и "CategoryName"). 
Теперь необходимо создать третью таблицу "ProductCategory", которая будет хранить связи между продуктами и категориями. Эта таблица должна содержать две колонки:

- ProductID (ссылка на уникальный идентификатор продукта из таблицы "Products")
- CategoryID (ссылка на уникальный идентификатор категории из таблицы "Categories")

Теперь мы можем написать SQL запрос для выбора всех пар «Имя продукта – Имя категории», включая продукты, у которых нет категорий. Для этого используем соединение между таблицами "Products" и "ProductCategory", а также соединение "LEFT JOIN" для включения продуктов без категорий:
```
SELECT Products.ProductName, ISNULL(Categories.CategoryName, 'No Category') AS CategoryName
FROM Products
LEFT JOIN ProductCategory ON Products.ProductID = ProductCategory.ProductID
LEFT JOIN Categories ON ProductCategory.CategoryID = Categories.CategoryID;
```
