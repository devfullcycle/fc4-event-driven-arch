db = db.getSiblingDB('hotel_reservation');

db.createCollection('inventory');
db.inventory.createIndex(
    { hotelId: 1, roomTypeId: 1, date: 1 },
    { name: 'idx_inventory_hotel_roomtype_date', unique: true }
);
db.inventory.createIndex(
    { hotelId: 1 },
    { name: 'idx_inventory_hotel' }
);
db.inventory.createIndex(
    { date: 1 },
    { name: 'idx_inventory_date' }
);

db.createCollection('reservations');
db.reservations.createIndex(
    { hotelId: 1, startDate: 1, endDate: 1 },
    { name: 'idx_reservations_hotel_dates' }
);
db.reservations.createIndex(
    { status: 1 },
    { name: 'idx_reservations_status' }
);
db.reservations.createIndex(
    { guestId: 1 },
    { name: 'idx_reservations_guest' }
);
db.reservations.createIndex(
    { hotelId: 1, status: 1 },
    { name: 'idx_reservations_hotel_status' }
);
db.reservations.createIndex(
    { createdAt: -1 },
    { name: 'idx_reservations_created_desc' }
);

