USE [TAL];
GO

-- ***************************************************************
-- ********* [dbo].[tblRating] ***********************************
-- ***************************************************************
INSERT INTO [dbo].[tblRating]
(
    [RatingName],
    [Factor]
)
VALUES
('Professional', 1.00);
GO

INSERT INTO [dbo].[tblRating]
(
    [RatingName],
    [Factor]
)
VALUES
('White Collar', 1.25);
GO

INSERT INTO [dbo].[tblRating]
(
    [RatingName],
    [Factor]
)
VALUES
('Light Manual', 1.50);
GO

INSERT INTO [dbo].[tblRating]
(
    [RatingName],
    [Factor]
)
VALUES
('Heavy Manual', 1.75);
GO


-- ***************************************************************
-- ********* [dbo].[tblOccupation] *******************************
-- ***************************************************************
INSERT INTO [dbo].[tblOccupation]
(
    [OccupationName],
    [RatingId]
)
VALUES
('Cleaner', 3);

INSERT INTO [dbo].[tblOccupation]
(
    [OccupationName],
    [RatingId]
)
VALUES
('Doctor', 1);

INSERT INTO [dbo].[tblOccupation]
(
    [OccupationName],
    [RatingId]
)
VALUES
('Author', 2);

INSERT INTO [dbo].[tblOccupation]
(
    [OccupationName],
    [RatingId]
)
VALUES
('Farmer', 4);

INSERT INTO [dbo].[tblOccupation]
(
    [OccupationName],
    [RatingId]
)
VALUES
('Mechanic', 4);

INSERT INTO [dbo].[tblOccupation]
(
    [OccupationName],
    [RatingId]
)
VALUES
('Florist', 3);
GO


