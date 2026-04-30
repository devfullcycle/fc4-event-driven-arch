db = db.getSiblingDB('hotel_reservation');

db.createCollection('inventory');
db.inventory.createIndex(
    { HotelId: 1, RoomTypeId: 1, Date: 1 },
    { name: 'idx_inventory_hotel_roomtype_date', unique: true }
);
db.inventory.createIndex(
    { HotelId: 1 },
    { name: 'idx_inventory_hotel' }
);
db.inventory.createIndex(
    { Date: 1 },
    { name: 'idx_inventory_date' }
);

db.createCollection('reservations');
db.reservations.createIndex(
    { HotelId: 1, StartDate: 1, EndDate: 1 },
    { name: 'idx_reservations_hotel_dates' }
);
db.reservations.createIndex(
    { Status: 1 },
    { name: 'idx_reservations_status' }
);
db.reservations.createIndex(
    { GuestId: 1 },
    { name: 'idx_reservations_guest' }
);
db.reservations.createIndex(
    { HotelId: 1, Status: 1 },
    { name: 'idx_reservations_hotel_status' }
);
db.reservations.createIndex(
    { CreatedAt: -1 },
    { name: 'idx_reservations_created_desc' }
);

