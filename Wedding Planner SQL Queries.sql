-- Create the Clients table
CREATE TABLE Clients (
    ClientID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    ContactNumber VARCHAR(15) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Address VARCHAR(255) NOT NULL
);
ALTER TABLE Clients  
ADD Password VARCHAR(255) NULL;

ALTER TABLE Clients
ADD ImageURL VARCHAR(500) NULL;

SELECT * FROM Clients;

-- Insert sample records into the Clients table
INSERT INTO Clients (FirstName, LastName, ContactNumber, Email, Address) VALUES
('John', 'Doe', '1234567890', 'john.doe@example.com', '123 Elm Street, Springfield'),
('Jane', 'Smith', '9876543210', 'jane.smith@example.com', '456 Oak Avenue, Lincoln'),
('Michael', 'Brown', '5678901234', 'michael.brown@example.com', '789 Pine Road, Boston'),
('Emily', 'Davis', '6789012345', 'emily.davis@example.com', '321 Maple Lane, Austin'),
('David', 'Wilson', '2345678901', 'david.wilson@example.com', '654 Birch Street, Denver'),
('Sophia', 'Taylor', '3456789012', 'sophia.taylor@example.com', '987 Cedar Avenue, Miami'),
('James', 'Anderson', '4567890123', 'james.anderson@example.com', '111 Palm Drive, Seattle'),
('Olivia', 'Thomas', '5678901234', 'olivia.thomas@example.com', '222 Magnolia Street, Atlanta'),
('William', 'Jackson', '6789012345', 'william.jackson@example.com', '333 Cherry Road, Portland'),
('Ava', 'White', '7890123456', 'ava.white@example.com', '444 Willow Way, Phoenix');

UPDATE Clients  
SET Password = 'John@123' WHERE FirstName = 'John' AND LastName = 'Doe';  
UPDATE Clients  
SET Password = 'Jane@123' WHERE FirstName = 'Jane' AND LastName = 'Smith';  
UPDATE Clients  
SET Password = 'Michael@123' WHERE FirstName = 'Michael' AND LastName = 'Brown';  
UPDATE Clients  
SET Password = 'Emily@123' WHERE FirstName = 'Emily' AND LastName = 'Davis';  
UPDATE Clients  
SET Password = 'David@123' WHERE FirstName = 'David' AND LastName = 'Wilson';  
UPDATE Clients  
SET Password = 'Sophia@123' WHERE FirstName = 'Sophia' AND LastName = 'Taylor';  
UPDATE Clients  
SET Password = 'James@123' WHERE FirstName = 'James' AND LastName = 'Anderson';  
UPDATE Clients  
SET Password = 'Olivia@123' WHERE FirstName = 'Olivia' AND LastName = 'Thomas';  
UPDATE Clients  
SET Password = 'William@123' WHERE FirstName = 'William' AND LastName = 'Jackson';  
UPDATE Clients  
SET Password = 'Ava@123' WHERE FirstName = 'Ava' AND LastName = 'White';  
UPDATE Clients  
SET Password = 'Hensi@123' WHERE FirstName = 'Hensi' AND LastName = 'Doshi'; 

UPDATE Clients 
SET ImageURL = 'http://captiontools.com/wp-content/uploads/2017/03/testy3-1.png' 
WHERE ClientID = 1;
UPDATE Clients 
SET ImageURL = 'https://a1cf74336522e87f135f-2f21ace9a6cf0052456644b80fa06d4f.ssl.cf2.rackcdn.com/images/characters/large/800/Jane-Smith.Mr-and-Mrs-Smith.webp' 
WHERE ClientID = 2;
UPDATE Clients 
SET ImageURL = 'https://m.media-amazon.com/images/M/MV5BMmQwNjEyNGYtOTAwYi00N2Q5LTk5YzYtZjA1YTRlYzZlYzIzXkEyXkFqcGc@._V1_.jpg' 
WHERE ClientID = 3;
UPDATE Clients 
SET ImageURL = 'https://media.press.amazonmgmstudios.com/userfiles/images/American_Rust/Season_2/Files/Headshot/emilyheadshot_thumb.JPG' 
WHERE ClientID = 4;
UPDATE Clients 
SET ImageURL = 'https://m.media-amazon.com/images/M/MV5BNTY5NTZlYjAtNmI0OC00MzkwLWJiOGMtYWY4NmRmYWY0NGVjXkEyXkFqcGc@._V1_.jpg' 
WHERE ClientID = 5;
UPDATE Clients 
SET ImageURL = 'https://images.mubicdn.net/images/cast_member/550293/cache-346762-1529019285/image-w856.jpg' 
WHERE ClientID = 6;
UPDATE Clients 
SET ImageURL = 'https://resources.ecb.co.uk/player-photos/test/800x800/900.png' 
WHERE ClientID = 7;
UPDATE Clients 
SET ImageURL = 'https://www.conservatoire.org.uk/assets/000/001/321/Olivia_Thomas_detail.jpg?1709640682' 
WHERE ClientID = 8;
UPDATE Clients 
SET ImageURL = 'https://www.hklaw.com/-/media/images/professionals/j/jackson-william/jackson_william_web.jpg?rev=ae6c3712c60a4a209709100e35b63294&sc_lang=en&hash=B6E426296198BA27E90285CE1E18646C' 
WHERE ClientID = 9;
UPDATE Clients 
SET ImageURL = 'https://ichef.bbci.co.uk/ace/ws/640/cpsprodpb/167BA/production/_121909029_1df92c56-01e9-49c3-bf26-3d0b79d172eb.jpg.webp' 
WHERE ClientID = 10;
UPDATE Clients 
SET ImageURL = 'http://captiontools.com/wp-content/uploads/2017/03/testy3-1.png' 
WHERE ClientID = 10014;
UPDATE Clients 
SET ImageURL = 'http://captiontools.com/wp-content/uploads/2017/03/testy3-1.png' 
WHERE ClientID = 14015;

SELECT * FROM Clients;

-- Create the Weddings table
CREATE TABLE Weddings (
    WeddingID INT PRIMARY KEY IDENTITY(1,1),
    WeddingDate DATE NOT NULL,
    WeddingLocation VARCHAR(255) NOT NULL,
    NumberOfGuests INT NOT NULL,
    Budget DECIMAL(10, 2) NOT NULL,
);
ALTER TABLE Weddings
ADD ImageURL VARCHAR(500);
ALTER TABLE Weddings
ADD Bride VARCHAR(255);
ALTER TABLE Weddings
ADD Groom VARCHAR(255);

-- Insert sample records into the Weddings table
INSERT INTO Weddings (WeddingDate, WeddingLocation, NumberOfGuests, Budget) VALUES
('2024-06-15', 'Central Park, New York', 120, 25000.00),
('2024-08-10', 'The Grand Ballroom, Chicago', 200, 40000.00),
('2024-05-20', 'Beachside Resort, Miami', 150, 30000.00),
('2024-09-12', 'Mountain View Estate, Denver', 80, 15000.00),
('2024-04-22', 'Lakeside Garden, Seattle', 100, 20000.00),
('2024-07-18', 'City Hall, San Francisco', 50, 10000.00),
('2024-10-25', 'Historic Mansion, Atlanta', 180, 35000.00),
('2024-03-05', 'Countryside Barn, Portland', 75, 18000.00),
('2024-11-30', 'Skyline Terrace, Los Angeles', 250, 50000.00),
('2024-12-20', 'Riverside Pavilion, Austin', 90, 22000.00);

UPDATE Weddings 
SET ImageURL = 'https://images-pw.pixieset.com/elementfield/380602131/froyle-park-weddings_112-287a25aa.jpg' 
WHERE WeddingID = 1;
UPDATE Weddings 
SET ImageURL = 'https://www.theplazany.com/wp-content/uploads/2016/02/Events_TheGrandBallroom_Hero_1.jpg' 
WHERE WeddingID = 2;
UPDATE Weddings 
SET ImageURL = 'https://www.rajwadaevents.com/uploaded-files/feature-images/Beach-Wedding05_09_55.jpg' 
WHERE WeddingID = 3;
UPDATE Weddings 
SET ImageURL = 'https://erinwheat.com/wp-content/uploads/2022/06/erin-wheat-co-mountain-view-turnout-elopement-breanna-jacob-4443.jpg' 
WHERE WeddingID = 4;
UPDATE Weddings 
SET ImageURL = 'https://cdn.wedding-spot.com/images/venues/8404/e70d10dd-31c4-4d61-9b46-2b284f12da27.jpg' 
WHERE WeddingID = 5;
UPDATE Weddings 
SET ImageURL = 'https://images.squarespace-cdn.com/content/v1/61d36b2814d30b415c9f3075/f1ef3da2-fadc-4126-af65-b53aee34faef/san-francisco-city-hall-wedding-5.jpg' 
WHERE WeddingID = 6;
UPDATE Weddings 
SET ImageURL = 'https://ailabomay.baamboostudio.com/member.baamboostudio.com/X-slider/uploads/f23a3fx15-a66xcd5f6-ci2134jsxms/venue-shot-sebelle-64d55cef4abf6.png' 
WHERE WeddingID = 7;
UPDATE Weddings 
SET ImageURL = 'https://assets.venuecrew.com/wp-content/uploads/2022/09/16063004/Country-wedding-venues-near-Brisbane-The-Bower-Estate-Gold-Coast-Rabbit-and-the-Bear-Photography.jpg' 
WHERE WeddingID = 8;
UPDATE Weddings 
SET ImageURL = 'https://www.littlevegaswedding.com/wp-content/uploads/2017/02/vegas-suite019.jpg' 
WHERE WeddingID = 9;
UPDATE Weddings 
SET ImageURL = 'https://cdn0.weddingwire.com/vendor/563450/3_2/960/jpg/78361934-1575550929264803-4886223733896773632-o_51_54365-158318344847600.jpeg' 
WHERE WeddingID = 10;
UPDATE Weddings 
SET ImageURL = 'https://content.jdmagicbox.com/comp/rajkot/dc/0281px281.x281.1228196568l9a2r7.dc/catalogue/krishna-party-plot-and-jay-sardar-caterers-mavdi-plot-rajkot-caterers-3h73wlv.jpeg' 
WHERE WeddingID = 8013;

UPDATE Weddings SET Bride = 'Aisha Patel', Groom = 'Rohan Mehta' WHERE WeddingID = 1;
UPDATE Weddings SET Bride = 'Priya Sharma', Groom = 'Arjun Verma' WHERE WeddingID = 2;
UPDATE Weddings SET Bride = 'Neha Gupta', Groom = 'Vikram Singh' WHERE WeddingID = 3;
UPDATE Weddings SET Bride = 'Simran Kaur', Groom = 'Kabir Malhotra' WHERE WeddingID = 4;
UPDATE Weddings SET Bride = 'Riya Desai', Groom = 'Aniket Joshi' WHERE WeddingID = 5;
UPDATE Weddings SET Bride = 'Sanya Kapoor', Groom = 'Rajesh Iyer' WHERE WeddingID = 6;
UPDATE Weddings SET Bride = 'Meera Nair', Groom = 'Siddharth Rao' WHERE WeddingID = 7;
UPDATE Weddings SET Bride = 'Pooja Mishra', Groom = 'Amit Tandon' WHERE WeddingID = 8;
UPDATE Weddings SET Bride = 'Kavita Saxena', Groom = 'Nikhil Bansal' WHERE WeddingID = 9;
UPDATE Weddings SET Bride = 'Anjali Chauhan', Groom = 'Manish Sinha' WHERE WeddingID = 10;
UPDATE Weddings SET Bride = 'Anjali Chauhan', Groom = 'Manish Sinha' WHERE WeddingID = 9014;

SELECT * FROM Weddings;

-- Create the Vendors table
CREATE TABLE Vendors (
    VendorID INT PRIMARY KEY IDENTITY(1,1),
    VendorName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    ContactNumber VARCHAR(15) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Address VARCHAR(255) NOT NULL
);
ALTER TABLE Vendors
ADD ImageURL NVARCHAR(500);

-- Insert sample records into the Vendors table
INSERT INTO Vendors (VendorName, Category, ContactNumber, Email, Address) VALUES
('Elegant Catering Co.', 'Catering', '1234567890', 'info@elegantcatering.com', '789 Elm Street, New York'),
('Dream Decorators', 'Decorations', '2345678901', 'contact@dreamdecorators.com', '456 Pine Avenue, Miami'),
('Picture Perfect', 'Photography', '3456789012', 'support@pictureperfect.com', '321 Oak Lane, Chicago'),
('Harmony Sounds', 'Music', '4567890123', 'hello@harmonysounds.com', '654 Birch Street, Denver'),
('Blissful Bakers', 'Cakes', '5678901234', 'orders@blissfulbakers.com', '111 Maple Drive, Austin'),
('Event Excellence', 'Planning', '6789012345', 'team@eventexcellence.com', '222 Cedar Way, Seattle'),
('Chic Rentals', 'Rentals', '7890123456', 'service@chicrentals.com', '333 Cherry Boulevard, Los Angeles'),
('Floral Elegance', 'Flowers', '8901234567', 'sales@floralelegance.com', '444 Willow Avenue, Portland'),
('Moments Captured', 'Videography', '9012345678', 'info@momentscaptured.com', '555 Palm Road, Atlanta'),
('Tasteful Tones', 'Music', '0123456789', 'contact@tastefultones.com', '666 Magnolia Street, Phoenix');

UPDATE Vendors 
SET ImageURL = 'https://5.imimg.com/data5/ANDROID/Default/2023/1/IQ/DX/NJ/160900430/product-jpeg-500x500.jpg' 
WHERE VendorID = 1;
UPDATE Vendors 
SET ImageURL = 'https://4.imimg.com/data4/SV/EF/MY-15238607/wedding-flower-decoration.jpg' 
WHERE VendorID = 2;
UPDATE Vendors 
SET ImageURL = 'https://www.yabeshphotography.com/wp-content/uploads/2023/05/Candid-vs.-Traditional-Wedding-Photography-Find-Your-Perfect-Style-Yabesh-Photography.jpg' 
WHERE VendorID = 3;
UPDATE Vendors 
SET ImageURL = 'https://boujeemusic.com/wp-content/uploads/2021/06/Dancing-at-Wedding-with-Live-Band.jpg' 
WHERE VendorID = 4;
UPDATE Vendors 
SET ImageURL = 'https://www.doorstepcake.com/wp-content/uploads/2023/09/elegant-two-tier-wedding-cake.jpg' 
WHERE VendorID = 5;
UPDATE Vendors 
SET ImageURL = 'https://www.signupgenius.com/cms/images/home/wedding-planning-made-easy-refresh-article-600x400.jpg' 
WHERE VendorID = 6;
UPDATE Vendors 
SET ImageURL = 'https://images.squarespace-cdn.com/content/v1/5757f5dcf85082d2ca1e509e/1612888127285-SV4QQL5RQFVDC03KDKEX/MissyMillys_EventRentals_Repurpose.gif' 
WHERE VendorID = 7;
UPDATE Vendors 
SET ImageURL = 'https://cdn0.weddingwire.com/article/7183/3_2/1280/jpg/23817-0-wild-fleur-co-ditto-dianto.jpeg' 
WHERE VendorID = 8;
UPDATE Vendors 
SET ImageURL = 'https://todaysbride.com/wp-content/uploads/2017/07/teale-rgb.jpg' 
WHERE VendorID = 9;
UPDATE Vendors 
SET ImageURL = 'https://boujeemusic.com/wp-content/uploads/2021/06/Dancing-at-Wedding-with-Live-Band.jpg' 
WHERE VendorID = 10;
UPDATE Vendors 
SET ImageURL = 'https://www.wholeblossoms.com/wedding-flowers-blog/wp-content/uploads/2024/12/IMG_6278-940x940.png' 
WHERE VendorID = 2012;

SELECT * FROM Vendors;

-- Create the VendorBookings table
CREATE TABLE VendorBookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    WeddingID INT NOT NULL,
    VendorID INT NOT NULL,
    ServiceCost DECIMAL(10, 2) NOT NULL,
    BookingDate DATE NOT NULL,
    Remarks VARCHAR(255),
    FOREIGN KEY (WeddingID) REFERENCES Weddings(WeddingID),
    FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID)
);

-- Insert sample records into the VendorBookings table
INSERT INTO VendorBookings (WeddingID, VendorID, ServiceCost, BookingDate, Remarks) VALUES
(1, 1, 5000.00, '2024-01-15', 'Catering services for 120 guests'),
(2, 2, 4000.00, '2024-02-10', 'Wedding hall decorations'),
(3, 3, 3000.00, '2024-03-20', 'Photography for the wedding'),
(4, 4, 2000.00, '2024-04-12', 'Live music performance'),
(5, 5, 1500.00, '2024-05-22', 'Flower arrangements'),
(6, 6, 1000.00, '2024-06-18', 'Wedding cake and desserts'),
(7, 7, 4500.00, '2024-07-25', 'Full catering services for 180 guests'),
(8, 8, 3500.00, '2024-08-05', 'Wedding photography and videography'),
(9, 9, 2500.00, '2024-09-30', 'DJ services and lighting setup'),
(10, 10, 3000.00, '2024-10-20', 'Venue setup and decoration');

SELECT * FROM VendorBookings;

-- Create the Tasks table
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    WeddingID INT NOT NULL,
    TaskDescription VARCHAR(255) NOT NULL,
    AssignedTo VARCHAR(100) NOT NULL,
    Deadline DATE NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (WeddingID) REFERENCES Weddings(WeddingID)
);
ALTER TABLE Tasks  
ALTER COLUMN ImageURL VARCHAR(500);


-- Insert sample records into the Tasks table
INSERT INTO Tasks (WeddingID, TaskDescription, AssignedTo, Deadline, Status) VALUES
(1, 'Finalize catering menu', 'Event Coordinator', '2024-05-01', 'Pending'),
(2, 'Confirm decoration themes', 'Decorator', '2024-06-15', 'Completed'),
(3, 'Hire photographer', 'Wedding Planner', '2024-04-30', 'Pending'),
(4, 'Arrange live band', 'Music Manager', '2024-08-01', 'Pending'),
(5, 'Order floral arrangements', 'Florist', '2024-03-15', 'Completed'),
(6, 'Design wedding invitations', 'Graphic Designer', '2024-02-28', 'Pending'),
(7, 'Confirm seating arrangements', 'Event Coordinator', '2024-07-10', 'Pending'),
(8, 'Arrange transport for guests', 'Transport Manager', '2024-09-05', 'Completed'),
(9, 'Prepare wedding cake', 'Baker', '2024-10-01', 'Pending'),
(10, 'Setup lighting for venue', 'Lighting Technician', '2024-11-15', 'Pending');

UPDATE Tasks  
SET ImageURL = 'https://nilacaterers.com/wp-content/uploads/2024/09/nila-august.jpg' 
WHERE TaskDescription = 'Finalize catering menu'; 
UPDATE Tasks  
SET ImageURL = 'https://www.shaadidukaan.com/vogue/wp-content/uploads/2019/05/daytime-wedding-decoration-ideas.jpg'  
WHERE TaskDescription = 'Confirm decoration themes'; 
UPDATE Tasks  
SET ImageURL = 'https://skyartmakers.com/wp-content/uploads/2023/02/Why-hire-a-professional-wedding-photographer-and-videographer.jpg'  
WHERE TaskDescription = 'Hire photographer';
UPDATE Tasks  
SET ImageURL = 'https://www.warble-entertainment.com/blog/wp-content/uploads/2015/03/Band.jpeg' 
WHERE TaskDescription = 'Arrange live band';
UPDATE Tasks  
SET ImageURL = 'https://www.bhg.com/thmb/cCZ7uGjcUzTnWZq-hIqDKHbctDI=/1722x0/filters:no_upscale():strip_icc()/orange-rose-green-floral-arrangement-2df42e9e-13583c40b3c041e88651518b8c0be1a3.jpg'  
WHERE TaskDescription = 'Order floral arrangements';
UPDATE Tasks  
SET ImageURL = 'https://www.craftyartapp.com/blog/wp-content/uploads/2023/06/0-6.jpg'  
WHERE TaskDescription = 'Design wedding invitations';
UPDATE Tasks  
SET ImageURL = 'https://cdn0.weddingwire.in/article/3905/3_2/960/jpg/75093-unique-seating-ideas-dreamzfrraft-lead.jpeg'  
WHERE TaskDescription = 'Confirm seating arrangements';  
UPDATE Tasks  
SET ImageURL = 'https://www.lapstonebarn.co.uk/app/uploads/2024/04/LR-150.jpg'  
WHERE TaskDescription = 'Arrange transport for guests';
UPDATE Tasks  
SET ImageURL = 'https://korenainthekitchen.com/wp-content/uploads/2014/08/img_3987.jpg'  
WHERE TaskDescription = 'Prepare wedding cake';
UPDATE Tasks  
SET ImageURL = 'https://wp-media-partyslate.imgix.net/2021/05/photo-9a957ea1-69fd-4f15-bb16-9649abd420a7.jpeg'  
WHERE TaskDescription = 'Setup lighting for venue';
UPDATE Tasks  
SET ImageURL = 'https://i.etsystatic.com/5861263/r/il/14fd48/5624931951/il_fullxfull.5624931951_ias6.jpg'  
WHERE TaskDescription = 'Red and white roses';

SELECT * FROM Tasks;

-- Create the Expenses table
CREATE TABLE Expenses (
    ExpenseID INT PRIMARY KEY IDENTITY(1,1),
    WeddingID INT NOT NULL,
    ExpenseDescription VARCHAR(255) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    Date DATE NOT NULL,
    FOREIGN KEY (WeddingID) REFERENCES Weddings(WeddingID)
);
	

-- Insert sample records into the Expenses table
INSERT INTO Expenses (WeddingID, ExpenseDescription, Amount, Date) VALUES
(1, 'Catering services', 5000.00, '2024-06-10'),
(2, 'Hall decoration', 4000.00, '2024-08-05'),
(3, 'Photography package', 3000.00, '2024-05-18'),
(4, 'Live band performance', 2000.00, '2024-09-10'),
(5, 'Floral arrangements', 1500.00, '2024-04-20'),
(6, 'Wedding invitations', 800.00, '2024-03-01'),
(7, 'Seating arrangements', 1200.00, '2024-07-15'),
(8, 'Transportation for guests', 2000.00, '2024-03-01'),
(9, 'Wedding cake and desserts', 1800.00, '2024-11-25'),
(10, 'Lighting setup', 2500.00, '2024-12-15');

SELECT * FROM Expenses;

-- Create the Guests table
CREATE TABLE Guests (
    GuestID INT PRIMARY KEY IDENTITY(1,1),
    WeddingID INT NOT NULL,
    GuestName VARCHAR(100) NOT NULL,
    ContactNumber VARCHAR(15),
    RSVPStatus VARCHAR(50) NOT NULL,
    MealPreference VARCHAR(100),
    FOREIGN KEY (WeddingID) REFERENCES Weddings(WeddingID)
);

-- Insert sample records into the Guests table
INSERT INTO Guests (WeddingID, GuestName, ContactNumber, RSVPStatus, MealPreference) VALUES 
(1, 'John Doe', '1234567890', 'Accepted', 'Vegetarian'),
(1, 'Jane Smith', '0987654321', 'Accepted', 'Non-Vegetarian'),
(2, 'Alice Brown', '5678901234', 'Declined', 'Vegan'),
(2, 'Bob Johnson', '4561237890', 'Accepted', 'Vegetarian'),
(3, 'Charlie White', '7890123456', 'Accepted', 'Gluten-Free'),
(3, 'Daisy Black', '3216549870', 'Pending', 'Vegetarian'),
(4, 'Eve Green', '6549871230', 'Accepted', 'Non-Vegetarian'),
(4, 'Frank Blue', '1230984567', 'Accepted', 'Vegan'),
(5, 'Grace Yellow', '9876543210', 'Declined', 'Vegetarian'),
(5, 'Hank Pink', '4567891230', 'Accepted', 'Non-Vegetarian');

SELECT * FROM Guests;

-- Create the Payments table
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    WeddingID INT NOT NULL,
    VendorID INT NOT NULL,
    AmountPaid DECIMAL(10, 2) NOT NULL,
    PaymentDate DATE NOT NULL,
    PaymentMethod VARCHAR(50) NOT NULL,
    FOREIGN KEY (WeddingID) REFERENCES Weddings(WeddingID),
    FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID)
);

-- Insert sample records into the Payments table
INSERT INTO Payments (WeddingID, VendorID, AmountPaid, PaymentDate, PaymentMethod) VALUES
(1, 1, 2500.00, '2024-05-15', 'Bank Transfer'),
(1, 2, 2000.00, '2024-05-20', 'Credit Card'),
(2, 3, 3000.00, '2024-07-05', 'Cash'),
(2, 4, 1000.00, '2024-07-10', 'Bank Transfer'),
(3, 5, 1500.00, '2024-04-01', 'Credit Card'),
(3, 6, 800.00, '2024-04-05', 'Cash'),
(4, 7, 2200.00, '2024-08-12', 'Bank Transfer'),
(5, 8, 1800.00, '2024-09-01', 'Credit Card'),
(6, 9, 1500.00, '2024-03-25', 'Cash'),
(7, 10, 2500.00, '2024-10-01', 'Bank Transfer');

SELECT * FROM Payments;

-- Create the Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    ContactNumber VARCHAR(15) NOT NULL,
    Address VARCHAR(255) NOT NULL,
    PreferredBudget DECIMAL(10, 2) NOT NULL,
    InterestedThemes VARCHAR(255) NOT NULL
);

-- Insert sample records into the Customers table
INSERT INTO Customers (FirstName, LastName, Email, ContactNumber, Address, PreferredBudget, InterestedThemes) VALUES
('Sophia', 'Williams', 'sophia.williams@example.com', '1112223333', '123 Maple Street, Chicago', 20000.00, 'Rustic, Vintage'),
('Liam', 'Johnson', 'liam.johnson@example.com', '2223334444', '456 Oak Avenue, San Diego', 15000.00, 'Modern, Minimalist'),
('Emma', 'Brown', 'emma.brown@example.com', '3334445555', '789 Pine Road, Miami', 18000.00, 'Romantic, Garden'),
('Noah', 'Davis', 'noah.davis@example.com', '4445556666', '321 Elm Street, New York', 22000.00, 'Beach, Tropical'),
('Olivia', 'Wilson', 'olivia.wilson@example.com', '5556667777', '654 Birch Lane, Austin', 25000.00, 'Classic, Elegant'),
('James', 'Smith', 'james.smith@example.com', '6667778888', '987 Cedar Drive, Portland', 17000.00, 'Bohemian, Rustic'),
('Ava', 'Taylor', 'ava.taylor@example.com', '7778889999', '321 Spruce Way, Atlanta', 23000.00, 'Vintage, Glamorous'),
('Mason', 'White', 'mason.white@example.com', '8889990000', '456 Cherry Blvd, Los Angeles', 19000.00, 'Modern, Romantic'),
('Isabella', 'Martinez', 'isabella.martinez@example.com', '9990001111', '789 Walnut Avenue, Seattle', 24000.00, 'Garden, Beach'),
('Ethan', 'Clark', 'ethan.clark@example.com', '0001112222', '123 Willow Court, Denver', 21000.00, 'Elegant, Minimalist');

SELECT * FROM Customers;

--Create the Feedbacks table
CREATE TABLE Feedbacks (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
	ClientID INT NOT NULL,
    WeddingID INT NOT NULL,             
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5), 
    Comments VARCHAR(100) NOT NULL,                             
    FeedbackDate DATE NOT NULL,    
    FOREIGN KEY (ClientID) REFERENCES Clients(ClientID), 
    FOREIGN KEY (WeddingID) REFERENCES Weddings(WeddingID) 
);

DROP TABLE Feedbacks;

-- Insert sample records into the Feedbacks table
INSERT INTO Feedbacks (ClientID, WeddingID, Rating, Comments, FeedbackDate)VALUES 
(1, 1, 5, 'Excellent service! The wedding was planned beautifully. Highly recommend.', '2025-01-01'),
(2, 2, 4, 'Great experience overall, but a few minor hiccups during the ceremony.', '2025-01-02'),
(3, 3, 3, 'The decor was good, but the catering service could have been better.', '2025-01-03'),
(4, 4, 5, 'Everything was perfect, from the venue selection to the event coordination.', '2025-01-04'),
(5, 5, 2, 'The wedding did not go as planned. There were several delays and mistakes.', '2025-01-05'),
(6, 6, 4, 'Wonderful wedding planning, though there were some issues with timing.', '2025-01-06'),
(7, 7, 5, 'Couldn’t have asked for a better wedding! Every detail was handled professionally.', '2025-01-07'),
(8, 8, 3, 'Good planning, but we were expecting more personalized touches.', '2025-01-08'),
(9, 9, 4, 'Nice overall experience, but some services were a bit overpriced.', '2025-01-09'),
(10, 10, 5, 'Exceptional service! Our wedding was a dream come true thanks to the planner.', '2025-01-10');

SELECT * FROM Feedbacks;

---------------------------------------------Stored Procedure----------------------------------------------------
-- 1) Clients
---- Select All
CREATE PROCEDURE [dbo].[PR_CLIENTS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Clients].[ClientID],
        [dbo].[Clients].[FirstName],
        [dbo].[Clients].[LastName],
		[dbo].[Clients].[ImageURL],
        [dbo].[Clients].[ContactNumber],
        [dbo].[Clients].[Email],
        [dbo].[Clients].[Address],
		[dbo].[Clients].[Password]
    FROM
        [dbo].[Clients]
    ORDER BY
		[dbo].[Clients].[ClientID],
        [dbo].[Clients].[FirstName],
        [dbo].[Clients].[LastName],
        [dbo].[Clients].[ContactNumber],
        [dbo].[Clients].[Email],
        [dbo].[Clients].[Address],
		[dbo].[Clients].[Password]
END;
EXEC [dbo].[PR_CLIENTS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_CLIENTS_SELECTBYPK]
    @ClientID INT
AS
BEGIN
    SELECT
        [dbo].[Clients].[ClientID],
        [dbo].[Clients].[FirstName],
        [dbo].[Clients].[LastName],
		[dbo].[Clients].[ImageURL],
        [dbo].[Clients].[ContactNumber],
        [dbo].[Clients].[Email],
        [dbo].[Clients].[Address],
		[dbo].[Clients].[Password]
    FROM
        [dbo].[Clients]
    WHERE
        [dbo].[Clients].[ClientID] = @ClientID
END;
EXEC [dbo].[PR_CLIENTS_SELECTBYPK] 5;

---- Insert
CREATE PROCEDURE [dbo].[PR_CLIENTS_INSERT]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
	@ImageURL NVARCHAR(500),
    @Email NVARCHAR(100),
    @ContactNumber NVARCHAR(15),
    @Address NVARCHAR(255),
	@Password NVARCHAR(255)
AS
BEGIN
    INSERT INTO [dbo].[Clients]
        ([FirstName], [LastName], [Email], [ContactNumber], [Address], [Password], [ImageURL])
    VALUES
        (@FirstName, @LastName, @Email, @ContactNumber, @Address, @Password, @ImageURL);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_CLIENTS_UPDATE]
    @ClientID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
	@ImageURL NVARCHAR(500),
    @Email NVARCHAR(100),
    @ContactNumber NVARCHAR(15),
    @Address NVARCHAR(255),
	@Password NVARCHAR(255)
AS
BEGIN
    UPDATE [dbo].[Clients]
    SET
        [FirstName] = @FirstName,
        [LastName] = @LastName,
		[ImageURL] = @ImageURL,
        [Email] = @Email,
        [ContactNumber] = @ContactNumber,
        [Address] = @Address,
		[Password] = @Password
    WHERE
        [ClientID] = @ClientID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_CLIENTS_DELETE]
    @ClientID INT
AS
BEGIN
    DELETE FROM [dbo].[Clients]
    WHERE [ClientID] = @ClientID
END;

---- Dropdown
CREATE PROCEDURE [dbo].[PR_CLIENTS_DROPDOWN]
AS
BEGIN
	SELECT
		[dbo].[Clients].[ClientID],
		CONCAT([dbo].[Clients].[FirstName], ' ', [dbo].[Clients].[LastName]) AS ClientFullName
	FROM
		[dbo].[Clients]
END;

-- 2) Weddings
---- Select All
CREATE PROCEDURE [dbo].[PR_WEDDINGS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[Bride],
		[dbo].[Weddings].[Groom],
        [dbo].[Weddings].[WeddingDate],
        [dbo].[Weddings].[WeddingLocation],
		[dbo].[Weddings].[ImageURL],
        [dbo].[Weddings].[NumberOfGuests],
        [dbo].[Weddings].[Budget]
    FROM
        [dbo].[Weddings]
    ORDER BY
		[dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[Bride],
		[dbo].[Weddings].[Groom],
        [dbo].[Weddings].[WeddingDate],
        [dbo].[Weddings].[WeddingLocation],
        [dbo].[Weddings].[NumberOfGuests],
        [dbo].[Weddings].[Budget]
END;
EXEC [dbo].[PR_WEDDINGS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_WEDDINGS_SELECTBYPK]
    @WeddingID INT
AS
BEGIN
    SELECT
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[Bride],
		[dbo].[Weddings].[Groom],
        [dbo].[Weddings].[WeddingDate],
        [dbo].[Weddings].[WeddingLocation],
		[dbo].[Weddings].[ImageURL],
		[dbo].[Weddings].[NumberOfGuests],
        [dbo].[Weddings].[Budget]
    FROM
        [dbo].[Weddings]
    WHERE
        [dbo].[Weddings].[WeddingID] = @WeddingID;
END;
EXEC [dbo].[PR_WEDDINGS_SELECTBYPK] 4;

---- Insert
CREATE PROCEDURE [dbo].[PR_WEDDINGS_INSERT]
    @WeddingDate DATE,
	@Bride NVARCHAR(255),
	@Groom NVARCHAR(255),
    @WeddingLocation NVARCHAR(255),
	@NumberOfGuests INT,
    @Budget DECIMAL(18, 2),
	@ImageURL NVARCHAR(500)
AS
BEGIN
    INSERT INTO [dbo].[Weddings]
        ([WeddingDate], [Bride], [Groom], [WeddingLocation],[NumberOfGuests], [Budget], [ImageURL])
    VALUES
        (@WeddingDate, @Bride, @Groom, @WeddingLocation, @NumberOfGuests, @Budget, @ImageURL)
END;

---- Update
CREATE PROCEDURE [dbo].[PR_WEDDINGS_UPDATE]
    @WeddingID INT,
	@Bride NVARCHAR(255),
	@Groom NVARCHAR(255),
    @WeddingDate DATE,
    @WeddingLocation NVARCHAR(255),
	@NumberOfGuests INT,
    @Budget DECIMAL(18, 2),
	@ImageURL NVARCHAR(255)
AS
BEGIN
    UPDATE [dbo].[Weddings]
    SET
		[Bride] = @Bride,
		[Groom] = @Groom,
        [WeddingDate] = @WeddingDate,
        [WeddingLocation] = @WeddingLocation,
		[NumberOfGuests] = @NumberOfGuests,
        [Budget] = @Budget,
		[ImageURL] = @ImageURL
    WHERE
        [WeddingID] = @WeddingID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_WEDDINGS_DELETE]
    @WeddingID INT
AS
BEGIN
    DELETE FROM [dbo].[Weddings]
    WHERE [WeddingID] = @WeddingID;
END;

---- Dropdown
CREATE PROCEDURE [dbo].[PR_WEDDINGS_DROPDOWN]
AS
BEGIN
	SELECT
		[dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate]
	FROM 
		[dbo].[Weddings]
END;

-- 3) Vendors
---- Select All
CREATE PROCEDURE [dbo].[PR_VENDORS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Vendors].[VendorID],
        [dbo].[Vendors].[VendorName],
		[dbo].[Vendors].[Category],
		[dbo].[Vendors].[ImageURL],
        [dbo].[Vendors].[ContactNumber],
        [dbo].[Vendors].[Email],
        [dbo].[Vendors].[Address]
    FROM
        [dbo].[Vendors]
    ORDER BY
        [dbo].[Vendors].[VendorID],
        [dbo].[Vendors].[VendorName],
		[dbo].[Vendors].[Category],
		[dbo].[Vendors].[ContactNumber],
		[dbo].[Vendors].[Email],
		[dbo].[Vendors].[Address];
END;
EXEC [dbo].[PR_VENDORS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_VENDORS_SELECTBYPK]
    @VendorID INT
AS
BEGIN
    SELECT
        [dbo].[Vendors].[VendorID],
        [dbo].[Vendors].[VendorName],
		[dbo].[Vendors].[Category],
		[dbo].[Vendors].[ImageURL],
        [dbo].[Vendors].[ContactNumber],
        [dbo].[Vendors].[Email],
        [dbo].[Vendors].[Address]
    FROM
        [dbo].[Vendors]
    WHERE
        [dbo].[Vendors].VendorID = @VendorID;
END;
EXEC [dbo].[PR_VENDORS_SELECTBYPK] 8;

---- Insert
CREATE PROCEDURE [dbo].[PR_VENDORS_INSERT]
    @VendorName NVARCHAR(100),
	@Category NVARCHAR(255),
    @ContactNumber NVARCHAR(15),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255),
	@ImageURL NVARCHAR(500)
AS
BEGIN
    INSERT INTO [dbo].[Vendors]
        ([VendorName],[Category], [ContactNumber], [Email], [Address], [ImageURL])
    VALUES
        (@VendorName, @Category, @ContactNumber, @Email, @Address, @ImageURL);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_VENDORS_UPDATE]
    @VendorID INT,
    @VendorName NVARCHAR(100),
	@Category NVARCHAR(255),
    @ContactNumber NVARCHAR(15),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255),
	 @ImageURL NVARCHAR(500)
AS
BEGIN
    UPDATE [dbo].[Vendors]
    SET
        [VendorName] = @VendorName,
		[Category] = @Category,
        [ContactNumber] = @ContactNumber,
        [Email] = @Email,
        [Address] = @Address,
		[ImageURL] = @ImageURL
    WHERE
        [VendorID] = @VendorID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_VENDORS_DELETE]
    @VendorID INT
AS
BEGIN
    DELETE FROM [dbo].[Vendors]
    WHERE [VendorID] = @VendorID;
END;

---- Dropdown
CREATE PROCEDURE [dbo].[PR_VENDORS_DROPDOWN]
AS
BEGIN
	SELECT
		[dbo].[Vendors].[VendorID],
		[dbo].[Vendors].[VendorName]
	FROM 
		[dbo].[Vendors]
END;

-- 4) VendorBookings
---- Select All
CREATE PROCEDURE [dbo].[PR_VENDORBOOKINGS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[VendorBookings].[BookingID],
		[dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Vendors].[VendorID],
		[dbo].[Vendors].[VendorName],
		[dbo].[VendorBookings].[ServiceCost],
        [dbo].[VendorBookings].[BookingDate],
        [dbo].[VendorBookings].[Remarks]
    FROM
        [dbo].[VendorBookings]
    INNER JOIN [dbo].[Vendors]
        ON [dbo].[VendorBookings].[VendorID] = [dbo].[Vendors].[VendorID]
    INNER JOIN [dbo].[Weddings]
        ON [dbo].[VendorBookings].[WeddingID] = [dbo].[Weddings].[WeddingID]
    ORDER BY
        [dbo].[VendorBookings].[BookingID],
		[dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Vendors].[VendorID],
		[dbo].[Vendors].[VendorName],
		[dbo].[VendorBookings].[ServiceCost],
        [dbo].[VendorBookings].[BookingDate],
        [dbo].[VendorBookings].[Remarks]
END;
EXEC [dbo].[PR_VENDORBOOKINGS_SELECTALL];

---- Select By PK
ALTER PROCEDURE [dbo].[PR_VENDORBOOKINGS_SELECTBYPK]
    @BookingID INT
AS
BEGIN
    SELECT
        [dbo].[VendorBookings].[BookingID],
		[dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Vendors].[VendorID],
		[dbo].[Vendors].[VendorName],
		[dbo].[VendorBookings].[ServiceCost],
        [dbo].[VendorBookings].[BookingDate],
        [dbo].[VendorBookings].[Remarks]
    FROM
        [dbo].[VendorBookings]
	INNER JOIN [dbo].[Vendors]
        ON [dbo].[VendorBookings].[VendorID] = [dbo].[Vendors].[VendorID]
    INNER JOIN [dbo].[Weddings]
        ON [dbo].[VendorBookings].[WeddingID] = [dbo].[Weddings].[WeddingID]
    WHERE
        [dbo].[VendorBookings].BookingID = @BookingID;
END;
EXEC [dbo].[PR_VENDORBOOKINGS_SELECTBYPK] 1;

---- Insert
CREATE PROCEDURE [dbo].[PR_VENDORBOOKINGS_INSERT]
    @WeddingID INT,
	@VendorID INT,
	@ServiceCost DECIMAL(10,2),
    @BookingDate DATE,
	@Remarks NVARCHAR(255)
AS
BEGIN
    INSERT INTO [dbo].[VendorBookings]
        ([WeddingID], [VendorID], [ServiceCost], [BookingDate], [Remarks])
    VALUES
        (@WeddingID, @VendorID, @ServiceCost, @BookingDate, @Remarks);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_VENDORBOOKINGS_UPDATE]
    @BookingID INT,
    @WeddingID INT,
    @VendorID INT,
    @ServiceCost DECIMAL(10,2),
    @BookingDate DATE,
	@Remarks NVARCHAR(255)
AS
BEGIN
    UPDATE [dbo].[VendorBookings]
    SET
		[WeddingID] = @WeddingID,
        [VendorID] = @VendorID,
		[ServiceCost] = @ServiceCost,
        [BookingDate] = @BookingDate,
        [Remarks] = @Remarks
    WHERE
        [BookingID] = @BookingID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_VENDORBOOKINGS_DELETE]
    @BookingID INT
AS
BEGIN
    DELETE FROM [dbo].[VendorBookings]
    WHERE [BookingID] = @BookingID;
END;

---- Dropdown
--CREATE PROCEDURE [dbo].[PR_VENDORBOOKINGS_DROPDOWN]
--AS
--BEGIN
--	SELECT 
--		[dbo].[VendorBookings].[BookingID],
--		[dbo].[VendorBookings].[BookingDate]
--	FROM
--		[dbo].[VendorBookings]
--END;

-- 5) Tasks
---- Select All
CREATE PROCEDURE [dbo].[PR_TASKS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Tasks].[TaskID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Tasks].[TaskDescription],
		[dbo].[Tasks].[ImageURL],
        [dbo].[Tasks].[AssignedTo],
        [dbo].[Tasks].[Deadline],
        [dbo].[Tasks].[Status]
    FROM
        [dbo].[Tasks]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Tasks].[WeddingID] = [dbo].[Weddings].[WeddingID]
    ORDER BY
        [dbo].[Tasks].[TaskID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Tasks].[TaskDescription],
        [dbo].[Tasks].[AssignedTo],
        [dbo].[Tasks].[Deadline],
        [dbo].[Tasks].[Status]
END;
EXEC [dbo].[PR_TASKS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_TASKS_SELECTBYPK]
    @TaskID INT
AS
BEGIN
    SELECT
        [dbo].[Tasks].[TaskID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Tasks].[TaskDescription],
		[dbo].[Tasks].[ImageURL],
        [dbo].[Tasks].[AssignedTo],
        [dbo].[Tasks].[Deadline],
        [dbo].[Tasks].[Status]
    FROM
        [dbo].[Tasks]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Tasks].[WeddingID] = [dbo].[Weddings].[WeddingID]
    WHERE
        [dbo].[Tasks].[TaskID] = @TaskID;
END;
EXEC [dbo].[PR_TASKS_SELECTBYPK] 9;

---- Insert
CREATE PROCEDURE [dbo].[PR_TASKS_INSERT]
    @WeddingID INT,
	@TaskDescription NVARCHAR(255),
    @AssignedTo NVARCHAR(100),
	@Deadline DATE,
    @Status NVARCHAR(50),
	@ImageURL NVARCHAR(500)  
AS
BEGIN
    INSERT INTO [dbo].[Tasks]
        ([WeddingID], [TaskDescription], [AssignedTo], [Deadline], [Status], [ImageURL])
    VALUES
        (@WeddingID, @TaskDescription, @AssignedTo, @Deadline, @Status, @ImageURL);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_TASKS_UPDATE]
    @TaskID INT,
	@WeddingID INT,
	@TaskDescription NVARCHAR(255),
    @AssignedTo NVARCHAR(100),	
	@Deadline DATE,
    @Status NVARCHAR(50),
	@ImageURL NVARCHAR(500)
AS
BEGIN
    UPDATE [dbo].[Tasks]
    SET
		[WeddingID] = @WeddingID,
		[TaskDescription] = @TaskDescription,
        [AssignedTo] = @AssignedTo,
        [Deadline] = @Deadline,
        [Status] = @Status,
		[ImageURL] = @ImageURL
    WHERE
        [dbo].[Tasks].[TaskID] = @TaskID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_TASKS_DELETE]
    @TaskID INT
AS
BEGIN
    DELETE FROM [dbo].[Tasks]
    WHERE
        [dbo].[Tasks].[TaskID] = @TaskID;
END;

---- Dropdown
--CREATE PROCEDURE [dbo].[PR_TASKS_DROPDOWN]
--AS
--BEGIN
--	SELECT
--		[dbo].[Tasks].[TaskID],
--		[dbo].[Tasks].[TaskDescription]
--	FROM
--		[dbo].[Tasks]
--END;

-- 6) Expenses
---- Select All
CREATE PROCEDURE [dbo].[PR_EXPENSES_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Expenses].[ExpenseID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Expenses].[ExpenseDescription],
        [dbo].[Expenses].[Amount],
        [dbo].[Expenses].[Date]
    FROM
        [dbo].[Expenses]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Expenses].[WeddingID] = [dbo].[Weddings].[WeddingID]
    ORDER BY
        [dbo].[Expenses].[ExpenseID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Expenses].[ExpenseDescription],
        [dbo].[Expenses].[Amount],
        [dbo].[Expenses].[Date]
END;
EXEC [dbo].[PR_EXPENSES_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_EXPENSES_SELECTBYPK]
    @ExpenseID INT
AS
BEGIN
    SELECT
        [dbo].[Expenses].[ExpenseID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Expenses].[ExpenseDescription],
        [dbo].[Expenses].[Amount],
        [dbo].[Expenses].[Date]
    FROM
        [dbo].[Expenses]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Expenses].[WeddingID] = [dbo].[Weddings].[WeddingID]
    WHERE
        [dbo].[Expenses].[ExpenseID] = @ExpenseID;
END;
EXEC [dbo].[PR_EXPENSES_SELECTBYPK] 3;

---- Insert
CREATE PROCEDURE [dbo].[PR_EXPENSES_INSERT]
    @WeddingID INT,
    @ExpenseDescription NVARCHAR(255),
    @Amount DECIMAL(18, 2),
    @Date DATE
AS
BEGIN
    INSERT INTO [dbo].[Expenses]
        ([WeddingID], [ExpenseDescription], [Amount], [Date])
    VALUES
        (@WeddingID, @ExpenseDescription, @Amount, @Date);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_EXPENSES_UPDATE]
    @ExpenseID INT,
    @WeddingID INT,
    @ExpenseDescription NVARCHAR(255),
    @Amount DECIMAL(18, 2),
    @Date DATE
AS
BEGIN
    UPDATE [dbo].[Expenses]
    SET
        [WeddingID] = @WeddingID,
        [ExpenseDescription] = @ExpenseDescription,
        [Amount] = @Amount,
        [Date] = @Date
    WHERE
        [dbo].[Expenses].[ExpenseID] = @ExpenseID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_EXPENSES_DELETE]
    @ExpenseID INT
AS
BEGIN
    DELETE FROM [dbo].[Expenses]
    WHERE
        [dbo].[Expenses].[ExpenseID] = @ExpenseID;
END;

---- Dropdown
--CREATE PROCEDURE [dbo].[PR_EXPENSES_DROPDOWN]
--AS
--BEGIN
--	SELECT
--		[dbo].[Expenses].[ExpenseID],
--		[dbo].[Expenses].[ExpenseDescription]
--	FROM
--		[dbo].[Expenses]
--END;

-- 7) Guests
----Select All
CREATE PROCEDURE [dbo].[PR_GUESTS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Guests].[GuestID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Guests].[GuestName],
        [dbo].[Guests].[ContactNumber],
        [dbo].[Guests].[RSVPStatus],
        [dbo].[Guests].[MealPreference]
    FROM
        [dbo].[Guests]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Guests].[WeddingID] = [dbo].[Weddings].[WeddingID]
    ORDER BY
        [dbo].[Guests].[GuestID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Guests].[GuestName],
        [dbo].[Guests].[ContactNumber],
        [dbo].[Guests].[RSVPStatus],
        [dbo].[Guests].[MealPreference]
END;
EXEC [dbo].[PR_GUESTS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_GUESTS_SELECTBYPK]
    @GuestID INT
AS
BEGIN
    SELECT
        [dbo].[Guests].[GuestID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Guests].[GuestName],
        [dbo].[Guests].[ContactNumber],
        [dbo].[Guests].[RSVPStatus],
        [dbo].[Guests].[MealPreference]
    FROM
        [dbo].[Guests]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Guests].[WeddingID] = [dbo].[Weddings].[WeddingID]
    WHERE
        [dbo].[Guests].[GuestID] = @GuestID;
END;
EXEC [dbo].[PR_GUESTS_SELECTBYPK] 6;

---- Insert
CREATE PROCEDURE [dbo].[PR_GUESTS_INSERT]
    @WeddingID INT,
    @GuestName NVARCHAR(50),
    @ContactNumber NVARCHAR(15),
    @RSVPStatus NVARCHAR(50),
    @MealPreference NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[Guests]
        ([WeddingID], [GuestName], [ContactNumber], [RSVPStatus], [MealPreference])
    VALUES
        (@WeddingID, @GuestName, @ContactNumber, @RSVPStatus, @MealPreference);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_GUESTS_UPDATE]
    @GuestID INT,
    @WeddingID INT,
    @GuestName NVARCHAR(50),
    @ContactNumber NVARCHAR(15),
    @RSVPStatus NVARCHAR(50),
    @MealPreference NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Guests]
    SET
        [WeddingID] = @WeddingID,
        [GuestName] = @GuestName,
        [ContactNumber] = @ContactNumber,
        [RSVPStatus] = @RSVPStatus,
        [MealPreference] = @MealPreference
    WHERE
        [dbo].[Guests].[GuestID] = @GuestID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_GUESTS_DELETE]
    @GuestID INT
AS
BEGIN
    DELETE FROM [dbo].[Guests]
    WHERE
        [dbo].[Guests].[GuestID] = @GuestID;
END;

---- Dropdown
--CREATE PROCEDURE [dbo].[PR_GUESTS_DROPDOWN]
--AS
--BEGIN
--	SELECT
--		[dbo].[Guests].[GuestID],
--		[dbo].[Guests].[GuestName]
--	FROM
--		[dbo].[Guests]
--END;

-- 8) Payments
---- Select All
CREATE PROCEDURE [dbo].[PR_PAYMENTS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Payments].[PaymentID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Vendors].[VendorID],
		[dbo].[Vendors].[VendorName],
        [dbo].[Payments].[AmountPaid],
        [dbo].[Payments].[PaymentDate],
        [dbo].[Payments].[PaymentMethod]
    FROM
        [dbo].[Payments]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Payments].[WeddingID] = [dbo].[Weddings].[WeddingID]
    INNER JOIN [dbo].[Vendors]
        ON [dbo].[Payments].[VendorID] = [dbo].[Vendors].[VendorID]
    ORDER BY
        [dbo].[Payments].[PaymentID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Vendors].[VendorID],
		[dbo].[Vendors].[VendorName],
        [dbo].[Payments].[AmountPaid],
        [dbo].[Payments].[PaymentDate],
        [dbo].[Payments].[PaymentMethod]
END;
EXEC [dbo].[PR_PAYMENTS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_PAYMENTS_SELECTBYPK]
    @PaymentID INT
AS
BEGIN
    SELECT
        [dbo].[Payments].[PaymentID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Vendors].[VendorID],
		[dbo].[Vendors].[VendorName],
        [dbo].[Payments].[AmountPaid],
        [dbo].[Payments].[PaymentDate],
        [dbo].[Payments].[PaymentMethod]
    FROM
        [dbo].[Payments]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Payments].[WeddingID] = [dbo].[Weddings].[WeddingID]
    INNER JOIN [dbo].[Vendors]
        ON [dbo].[Payments].[VendorID] = [dbo].[Vendors].[VendorID]
    WHERE
        [dbo].[Payments].[PaymentID] = @PaymentID;
END;
EXEC [dbo].[PR_PAYMENTS_SELECTBYPK] 1;

---- Insert
CREATE PROCEDURE [dbo].[PR_PAYMENTS_INSERT]
    @WeddingID INT,
	@VendorID INT,
    @AmountPaid DECIMAL(18, 2),
	@PaymentDate DATE,
    @PaymentMethod NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[Payments]
        ([WeddingID], [VendorID], [AmountPaid], [PaymentDate], [PaymentMethod])
    VALUES
        (@WeddingID, @VendorID, @AmountPaid, @PaymentDate, @PaymentMethod);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_PAYMENTS_UPDATE]
    @PaymentID INT,
    @WeddingID INT,
	@VendorID INT,
    @AmountPaid DECIMAL(18, 2),
	@PaymentDate DATE,
    @PaymentMethod NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Payments]
    SET
        [WeddingID] = @WeddingID,
        [VendorID] = @VendorID,
        [AmountPaid] = @AmountPaid,
        [PaymentDate] = @PaymentDate,
        [PaymentMethod] = @PaymentMethod
    WHERE
        [dbo].[Payments].[PaymentID] = @PaymentID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_PAYMENTS_DELETE]
    @PaymentID INT
AS
BEGIN
    DELETE FROM [dbo].[Payments]
    WHERE
        [dbo].[Payments].[PaymentID] = @PaymentID;
END;

---- Dropdown
--CREATE PROCEDURE [dbo].[PR_PAYMENTS_DROPDOWN]
--AS
--BEGIN
--	SELECT
--		[dbo].[Payments].[PaymentID],
--		[dbo].[Payments].[PaymentDate]
--	FROM
--		[dbo].[Payments]
--END;

-- 9) Customers
---- Select All
CREATE PROCEDURE [dbo].[PR_CUSTOMERS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Customers].[CustomerID],
        [dbo].[Customers].[FirstName],
        [dbo].[Customers].[LastName],
		[dbo].[Customers].[Email],
        [dbo].[Customers].[ContactNumber],
        [dbo].[Customers].[Address],
        [dbo].[Customers].[PreferredBudget],
		[dbo].[Customers].[InterestedThemes]
    FROM
        [dbo].[Customers]
    ORDER BY
        [dbo].[Customers].[CustomerID],
        [dbo].[Customers].[FirstName],
        [dbo].[Customers].[LastName],
		[dbo].[Customers].[Email],
        [dbo].[Customers].[ContactNumber],
        [dbo].[Customers].[Address],
        [dbo].[Customers].[PreferredBudget],
		[dbo].[Customers].[InterestedThemes]
END;
EXEC [dbo].[PR_CUSTOMERS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_CUSTOMERS_SELECTBYPK]
    @CustomerID INT
AS
BEGIN
    SELECT
        [dbo].[Customers].[CustomerID],
        [dbo].[Customers].[FirstName],
        [dbo].[Customers].[LastName],
		[dbo].[Customers].[Email],
        [dbo].[Customers].[ContactNumber],
        [dbo].[Customers].[Address],
        [dbo].[Customers].[PreferredBudget],
		[dbo].[Customers].[InterestedThemes]
    FROM
        [dbo].[Customers]
    WHERE
        [dbo].[Customers].[CustomerID] = @CustomerID;
END;
EXEC [dbo].[PR_CUSTOMERS_SELECTBYPK] 7;

---- Insert
CREATE PROCEDURE [dbo].[PR_CUSTOMERS_INSERT]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
	@Email NVARCHAR(100),
    @ContactNumber NVARCHAR(15),
    @Address NVARCHAR(255),
	@PreferredBudget DECIMAL(18,2),
	@InterestedThemes NVARCHAR(255)
AS
BEGIN
    INSERT INTO [dbo].[Customers]
        ([FirstName], [LastName], [Email], [ContactNumber], [Address], [PreferredBudget], [InterestedThemes])
    VALUES
        (@FirstName, @LastName, @Email, @ContactNumber, @Address, @PreferredBudget, @InterestedThemes);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_CUSTOMERS_UPDATE]
    @CustomerID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
	@Email NVARCHAR(100),
    @ContactNumber NVARCHAR(15),
    @Address NVARCHAR(255),
	@PreferredBudget DECIMAL(18,2),
	@InterestedThemes NVARCHAR(255)
AS
BEGIN
    UPDATE [dbo].[Customers]
    SET
        [FirstName] = @FirstName,
        [LastName] = @LastName,
		[Email] = @Email,
        [ContactNumber] = @ContactNumber,
        [Address] = @Address,
		[PreferredBudget] = @PreferredBudget,
		[InterestedThemes] = @InterestedThemes
    WHERE
        [dbo].[Customers].[CustomerID] = @CustomerID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_CUSTOMERS_DELETE]
    @CustomerID INT
AS
BEGIN
    DELETE FROM [dbo].[Customers]
    WHERE [dbo].[Customers].[CustomerID] = @CustomerID;
END;

---- Dropdown
CREATE PROCEDURE [dbo].[PR_CUSTOMERS_DROPDOWN]
AS
BEGIN
	SELECT
		[dbo].[Customers].[CustomerID],
		[dbo].[Customers].[FirstName],
		[dbo].[Customers].[LastName]
	FROM
		[dbo].[Customers]
END;

-- 10) Feedbacks
CREATE PROCEDURE [dbo].[PR_FEEDBACKS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Feedbacks].[FeedbackID],
        [dbo].[Clients].[ClientID],
		CONCAT([dbo].[Clients].[FirstName], ' ', [dbo].[Clients].[LastName]) AS ClientFullName,
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Feedbacks].[Rating],
        [dbo].[Feedbacks].[Comments],
        [dbo].[Feedbacks].[FeedbackDate]
    FROM
        [dbo].[Feedbacks]
    INNER JOIN [dbo].[Weddings]
        ON [dbo].[Feedbacks].[WeddingID] = [dbo].[Weddings].[WeddingID]
    INNER JOIN [dbo].[Clients]
        ON [dbo].[Feedbacks].[ClientID] = [dbo].[Clients].[ClientID]
    ORDER BY
        [dbo].[Feedbacks].[FeedbackID],
        [dbo].[Clients].[ClientID],
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Feedbacks].[Rating],
        [dbo].[Feedbacks].[Comments],
        [dbo].[Feedbacks].[FeedbackDate]
END;
EXEC [dbo].[PR_FEEDBACKS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_FEEDBACKS_SELECTBYPK]
    @FeedbackID INT
AS
BEGIN
    SELECT
        [dbo].[Feedbacks].[FeedbackID],
        [dbo].[Clients].[ClientID],
		CONCAT([dbo].[Clients].[FirstName], ' ', [dbo].[Clients].[LastName]) AS ClientFullName,
        [dbo].[Weddings].[WeddingID],
		[dbo].[Weddings].[WeddingDate],
        [dbo].[Feedbacks].[Rating],
        [dbo].[Feedbacks].[Comments],
        [dbo].[Feedbacks].[FeedbackDate]
    FROM
        [dbo].[Feedbacks]
	INNER JOIN [dbo].[Weddings]
        ON [dbo].[Feedbacks].[WeddingID] = [dbo].[Weddings].[WeddingID]
    INNER JOIN [dbo].[Clients]
        ON [dbo].[Feedbacks].[ClientID] = [dbo].[Clients].[ClientID]
    WHERE
        [dbo].[Feedbacks].[FeedbackID] = @FeedbackID;
END;
EXEC [dbo].[PR_FEEDBACKS_SELECTBYPK] 4;

---- Insert
CREATE PROCEDURE [dbo].[PR_FEEDBACKS_INSERT]
    @ClientID INT,
    @WeddingID INT,
    @Rating INT,
    @Comments NVARCHAR(255),
    @FeedbackDate DATE
AS
BEGIN
    INSERT INTO [dbo].[Feedbacks]
        ([ClientID], [WeddingID], [Rating], [Comments], [FeedbackDate])
    VALUES
        (@ClientID, @WeddingID, @Rating, @Comments, @FeedbackDate);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_FEEDBACKS_UPDATE]
    @FeedbackID INT,
    @ClientID INT,
    @WeddingID INT,
    @Rating INT,
    @Comments NVARCHAR(255),
    @FeedbackDate DATE
AS
BEGIN
    UPDATE [dbo].[Feedbacks]
    SET
        [ClientID] = @ClientID,
        [WeddingID] = @WeddingID,
        [Rating] = @Rating,
        [Comments] = @Comments,
        [FeedbackDate] = @FeedbackDate
    WHERE
        [dbo].[Feedbacks].[FeedbackID] = @FeedbackID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_FEEDBACKS_DELETE]
    @FeedbackID INT
AS
BEGIN
    DELETE FROM [dbo].[Feedbacks]
    WHERE
        [dbo].[Feedbacks].[FeedbackID] = @FeedbackID;
END;

---- Dropdwon
--CREATE PROCEDURE [dbo].[PR_FEEDBACKS_DROPDOWN]
--AS
--BEGIN
--	SELECT
--		[dbo].[Feedbacks].[FeedbackID],
--		[dbo].[Feedbacks].[FeedbackDate]
--	FROM
--		[dbo].[Feedbacks]
--END;

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(15) UNIQUE NOT NULL,
    Address NVARCHAR(255) NULL,
    Role NVARCHAR(50) NOT NULL 
);

INSERT INTO Users (UserName, Email, Password, PhoneNumber, Address, Role)  
VALUES  
    ('John Doe', 'john.doe@example.com', 'John@123', '9876543210', '123 Main St, NY', 'Admin'),  
    ('Jane Smith', 'jane.smith@example.com', 'Jane@123', '8765432109', '456 Oak St, CA', 'User'),  
    ('Michael Johnson', 'michael.j@example.com', 'Michael@123', '7654321098', '789 Pine St, TX', 'User'),  
    ('Emily Brown', 'emily.b@example.com', 'Emily@123', '6543210987', '101 Maple St, FL', 'User'),  
    ('David White', 'david.w@example.com', 'David@123', '5432109876', '202 Cedar St, WA', 'User'),  
    ('Sophia Green', 'sophia.g@example.com', 'Sophia@123', '4321098765', '303 Birch St, IL', 'User'),  
    ('James Wilson', 'james.w@example.com', 'James@123', '3210987654', '404 Walnut St, NJ', 'Admin'),  
    ('Olivia Clark', 'olivia.c@example.com', 'Olivia@123', '2109876543', '505 Spruce St, MA', 'User'),  
    ('William Adams', 'william.a@example.com', 'William@123', '1098765432', '606 Elm St, AZ', 'User'),  
    ('Ava Harris', 'ava.h@example.com', 'Ava@123', '0987654321', '707 Redwood St, CO', 'User');  

SELECT * FROM Users;

---- Select All
CREATE PROCEDURE [dbo].[PR_USERS_SELECTALL]
AS
BEGIN
    SELECT
        [dbo].[Users].[UserID],
        [dbo].[Users].[UserName],
        [dbo].[Users].[Email],
		[dbo].[Users].[Password],
        [dbo].[Users].[PhoneNumber],
        [dbo].[Users].[Address],
        [dbo].[Users].[Role]
    FROM
        [dbo].[Users]
    ORDER BY
        [dbo].[Users].[UserID],
        [dbo].[Users].[UserName],
        [dbo].[Users].[Email],
		[dbo].[Users].[Password],
        [dbo].[Users].[PhoneNumber],
        [dbo].[Users].[Address],
        [dbo].[Users].[Role];
END;
EXEC [dbo].[PR_USERS_SELECTALL];

---- Select By PK
CREATE PROCEDURE [dbo].[PR_USERS_SELECTBYPK]
    @UserID INT
AS
BEGIN
    SELECT
        [dbo].[Users].[UserID],
        [dbo].[Users].[UserName],
        [dbo].[Users].[Email],
		[dbo].[Users].[Password],
        [dbo].[Users].[PhoneNumber],
        [dbo].[Users].[Address],
        [dbo].[Users].[Role]
    FROM
        [dbo].[Users]
    WHERE
        [dbo].[Users].[UserID] = @UserID;
END;
EXEC [dbo].[PR_USERS_SELECTBYPK] 1;

---- Insert
CREATE PROCEDURE [dbo].[PR_USERS_INSERT]
    @UserName NVARCHAR(100),
    @Email NVARCHAR(255),
	@Password NVARCHAR(255),
    @PhoneNumber NVARCHAR(15),
    @Address NVARCHAR(255),
    @Role NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[Users]
        ([UserName], [Email], [Password], [PhoneNumber], [Address], [Role])
    VALUES
        (@UserName, @Email, @Password, @PhoneNumber, @Address, @Role);
END;

---- Update
CREATE PROCEDURE [dbo].[PR_USERS_UPDATE]
    @UserID INT,
    @UserName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Password NVARCHAR(255),
    @PhoneNumber NVARCHAR(15),
    @Address NVARCHAR(255),
    @Role NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Users]
    SET
        [UserName] = @UserName,
        [Email] = @Email,
        [Password] = @Password,
        [PhoneNumber] = @PhoneNumber,
        [Address] = @Address,
        [Role] = @Role
    WHERE
        [dbo].[Users].[UserID] = @UserID;
END;

---- Delete
CREATE PROCEDURE [dbo].[PR_USERS_DELETE]
    @UserID INT
AS
BEGIN
    DELETE FROM [dbo].[Users]
    WHERE
        [dbo].[Users].[UserID] = @UserID;
END;

-- Register User
CREATE PROCEDURE [dbo].[PR_User_SignUp]
    @UserName NVARCHAR(50),
    @Password NVARCHAR(50),
    @Email NVARCHAR(500),
    @PhoneNumber VARCHAR(50),
    @Address VARCHAR(500),
    @Role NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[Users]
    (
        [UserName],
        [Password],
        [Email],
        [PhoneNumber],
        [Address],
        [Role]
    )
    VALUES
    (
        @UserName,
        @Password,
        @Email,
        @PhoneNumber,
        @Address,
        @Role
    );
END;
EXEC PR_User_SignUp 
    @UserName = 'Satish', 
    @Password = 'Hdsp@2107', 
    @Email = 'satish123@gmail.com', 
    @PhoneNumber = '1234567890', 
    @Address = 'Rajkot', 
    @Role = 'Admin';


-- Login User
CREATE PROCEDURE [dbo].[PR_User_Login]
    @UserName NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SELECT 
        [dbo].[Users].[UserID], 
        [dbo].[Users].[UserName], 
        [dbo].[Users].[PhoneNumber], 
        [dbo].[Users].[Email], 
        [dbo].[Users].[Password],
        [dbo].[Users].[Address],
        [dbo].[Users].[Role]
    FROM 
        [dbo].[Users] 
    WHERE 
        [dbo].[Users].[UserName] = @UserName 
        AND [dbo].[Users].[Password] = @Password;
END;

EXEC PR_User_Login 
    @UserName = 'Hensi', 
    @Password = 'Hdsp@2107';

select * from ContactForms;
