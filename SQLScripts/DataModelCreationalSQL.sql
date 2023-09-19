-- Create DiscountType Table
CREATE TABLE DiscountType (
    DiscountTypeID INT PRIMARY KEY,
    DiscountTypeName NVARCHAR(255)
);

-- Create DiscountRule Table
CREATE TABLE DiscountRule (
    DiscountRuleID INT PRIMARY KEY,
    DiscountRuleName NVARCHAR(255),
    DiscountTypeID INT,
    FOREIGN KEY (DiscountTypeID) REFERENCES DiscountType(DiscountTypeID)
);

-- Create Discount_Weekly Table
CREATE TABLE Discount_Weekly (
    ID INT PRIMARY KEY,
    Days NVARCHAR(255),
    Percents INT,
    DiscountRuleID INT,
    FOREIGN KEY (DiscountRuleID) REFERENCES DiscountRule(DiscountRuleID)
);

-- Insert Sample Data

-- Insert Sample Data into DiscountType Table
INSERT INTO DiscountType (DiscountTypeID, DiscountTypeName)
VALUES
    (1, 'Regular'),
    (2, 'Silver'),
    (3, 'Gold'),
    (4, 'Platinum'),
    (5, 'VIP');

-- Insert Sample Data into DiscountRule Table
INSERT INTO DiscountRule (DiscountRuleID, DiscountRuleName, DiscountTypeID)
VALUES
    (1, 'Weekly Standard Discount', 1),
    (2, 'Silver Member Weekly Discount', 2),
    (3, 'Gold Member Weekly Discount', 3),
    (4, 'Platinum Member Weekly Discount', 4),
    (5, 'VIP Member Weekly Discount', 5);

-- Insert Sample Data into Discount_Weekly Table
-- (Sample data for Days and Percent is from your example)
INSERT INTO Discount_Weekly (ID, Days, Percents, DiscountRuleID)
VALUES
    (1, 'Monday', 5, 1),
    (2, 'Tuesday', 4, 1),
    (3, 'Wednesday', 3, 1),
    (4, 'Thursday', 2, 1),
    (5, 'Friday', 1, 1),
    (6, 'Monday', 7, 2),
    (7, 'Tuesday', 6, 2),
    (8, 'Wednesday', 5, 2),
    (9, 'Thursday', 4, 2),
    (10, 'Friday', 3, 2),
    (11, 'Monday', 10, 3),
    (12, 'Tuesday', 9, 3),
    (13, 'Wednesday', 8, 3),
    (14, 'Thursday', 7, 3),
    (15, 'Friday', 6, 3),
    (16, 'Monday', 15, 4),
    (17, 'Tuesday', 14, 4),
    (18, 'Wednesday', 13, 4),
    (19, 'Thursday', 12, 4),
    (20, 'Friday', 11, 4),
    (21, 'Monday', 20, 5),
    (22, 'Tuesday', 19, 5),
    (23, 'Wednesday', 18, 5),
    (24, 'Thursday', 17, 5),
    (25, 'Friday', 16, 5);
