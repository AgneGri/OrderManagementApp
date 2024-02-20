CREATE TABLE Orders(
    [Id] INT IDENTITY PRIMARY KEY CLUSTERED,
    [Name] VARCHAR(50) NOT NULL,
    [State] CHAR(2) UNIQUE NOT NULL
);

CREATE TABLE Windows(
    [Id] INT IDENTITY PRIMARY KEY CLUSTERED,
    [OrderId] INT NOT NULL,
    [Name] CHAR(3) UNIQUE NOT NULL,
    [QuantityOfWindows] INT NOT NULL,
    [TotalSubElements] INT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);

CREATE TABLE SubElements(
    [Id] INT IDENTITY PRIMARY KEY CLUSTERED,
    [WindowId] INT NOT NULL,
    [Type] CHAR(3) UNIQUE NOT NULL,
    [Width] INT NOT NULL,
    [Height] INT NOT NULL
    FOREIGN KEY (WindowId) REFERENCES Windows(Id)
);

INSERT INTO Orders([Name], [State])
VALUES('New York Building 1', 'NY');

SELECT * FROM Orders;