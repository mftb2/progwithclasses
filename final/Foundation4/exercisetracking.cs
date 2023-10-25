import datetime

class Activity:
    def __init__(self, activity_type, date, duration):
        self.activity_type = activity_type
        self.date = date
        self.duration = duration

    def get_distance(self):
        return 0  # Base class returns 0, overridden in derived classes

    def get_speed(self):
        return 0  # Base class returns 0, overridden in derived classes

    def get_pace(self):
        return 0  # Base class returns 0, overridden in derived classes

    def get_summary(self):
        return f"{self.date} {self.activity_type} ({self.duration} min)"

class Running(Activity):
    def __init__(self, date, duration, distance):
        super().__init__("Running", date, duration)
        self.distance = distance

    def get_distance(self):
        return self.distance

    def get_speed(self):
        return round((self.distance / self.duration) * 60, 2)

    def get_pace(self):
        return round((self.duration / self.distance), 2)

    def get_summary(self):
        return f"{super().get_summary()} - Distance {self.distance} miles, Speed {self.get_speed()} mph, Pace: {self.get_pace()} min per mile"

class Cycling(Activity):
    def __init__(self, date, duration, speed):
        super().__init__("Cycling", date, duration)
        self.speed = speed

    def get_speed(self):
        return self.speed

    def get_distance(self):
        return round((self.speed * self.duration) / 60, 2)

    def get_pace(self):
        return round(60 / self.speed, 2)

    def get_summary(self):
        return f"{super().get_summary()} - Speed {self.speed} kph, Distance {self.get_distance()} km, Pace: {self.get_pace()} min per km"

class Swimming(Activity):
    def __init__(self, date, duration, laps):
        super().__init__("Swimming", date, duration)
        self.laps = laps

    def get_distance(self):
        return round((self.laps * 50) / 1000, 2)

    def get_speed(self):
        return round((self.get_distance() / self.duration) * 60, 2)

    def get_pace(self):
        return round((self.duration / self.get_distance()), 2)

    def get_summary(self):
        return f"{super().get_summary()} - Distance {self.get_distance()} km, Speed {self.get_speed()} kph, Pace: {self.get_pace()} min per km"

# Create activity instances
activities = [
    Running(datetime.date(2022, 11, 3), 30, 3.0),
    Running(datetime.date(2022, 11, 3), 30, 4.8),
    Cycling(datetime.date(2022, 11, 3), 45, 20),
    Swimming(datetime.date(2022, 11, 3), 60, 40),
]

# Display activity summaries
for activity in activities:
    print(activity.get_summary())
