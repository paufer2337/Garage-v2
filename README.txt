=== C# Övning 3 - Garage Console App ===
___________________________________________________________


¤ Hur är programmets struktur uppbyggd?

 - Program.cs      (UI + huvudmeny + användarinteraktion)
 - Garage.cs       (Garage-logik + hantering av vehicle-array)
 - Vehicle.cs      (Abstrakt basklass för alla fordon)
 - Helpers.cs      (Validering + hjälpmetoder)

===========================================================


¤ Vilka klasser innehåller programmet?


~ Basklass:
|   Vehicle         = Gemensam basklass för alla fordon                       |

~ Subklasser:
|   Car                                                                       |
|   Motorcycle                                                                |
|   Bus                                                                       |
|   Boat                                                                      |
|   Airplane                                                                  |

~ Hjälpklass:
|   Helpers         = Input-validation + countdown/pause                      |

===========================================================


¤ Vilka funktioner/metoder innehåller programmet?


~ Program.cs:
|   Main                = Startar programmet + hanterar huvudmeny             |
|   CreateGarage        = Skapar garage med valfri kapacitet                  |
|   PopulateGarage      = Lägger till fordon direkt vid start                 |
|   AddVehicle          = Skapar + lägger till nytt fordon                    |
|   RemoveVehicle       = Tar bort fordon via registreringsnummer             |
|   SearchByRegNr       = Söker efter fordon via registreringsnummer          |
|   SearchByProperties  = Meny för sökning via egenskaper                     |

~ Garage.cs:
|   AddVehicle          = Parkerar fordon i första lediga plats               |
|   RemoveVehicle       = Tar bort fordon från array                          |
|   ParkedVehicles      = Skriver ut alla parkerade fordon                    |
|   VehiclesByType      = Räknar antal fordon per typ                         |
|   SearchByRegNr       = Söker efter matchande registreringsnummer           |
|   SearchByProperty    = Söker via vald property                             |

~ Vehicle.cs:
|   GetInfo             = Returnerar grundläggande fordonsinfo                |
|   GetExtraInfo        = Returnerar subclass-specifik property               |

~ Helpers.cs:
|   GetValidText        = Validerar text-input                                |
|   GetValidInt         = Validerar heltal                                    |
|   GetValidDouble      = Validerar decimaltal                                |
|   Pause               = Väntar på tangenttryck                              |
|   CountDownToMenu     = Timer innan återgång till meny                      |

===========================================================


¤ Vad innehåller programmet logiskt?


~ OOP / Objektorientering:
|   Inheritance     = Alla fordon ärver från Vehicle                          |
|   Polymorphism    = Garage lagrar alla fordon som Vehicle                   |
|   Override        = Subklasser override:ar GetExtraInfo()                   |
|   Encapsulation   = Properties används istället för publika fält            |

~ Kontrollflöde:
|   switch           = Hanterar menyval + vehicle-val                         |
|   if / else        = Validering + sök/filter-logik                          |

~ Loopar:
|   while            = Håller menyer igång                                    |
|   foreach          = Itererar genom garage-array                            |
|   for              = Itererar parkeringsplatser                             |

~ Arrayer:
|   Vehicle?[]       = Representerar garage/parkeringsplatser                 |

===========================================================


¤ Extra properties per fordon:


|   Car             = FuelType                                                |
|   Motorcycle      = CylinderVolume                                          |
|   Bus             = SeatAmount                                              |
|   Boat            = Length                                                  |
|   Airplane        = EngineAmount                                            |

===========================================================


¤ Extra funktionalitet:


|   Input-validation    = Hanterar felaktig input                             |
|   Registration-format = Standardiserar regnr via Replace + ToUpper          |
|   Duplicate-check     = Förhindrar dubbla registreringsnummer               |
|   Search-system       = Söker via vald property                             |
|   UX/UI               = Tydliga menyer + tabellbaserad output               |
|   Console.Clear()     = Renare flöde mellan menyer/output                   |
|   Dynamic output      = Extra-info visas beroende på vehicle-typ            |

===========================================================


¤ Filhantering / Persistence:


|   FileHandler.cs    = Hanterar save/load via CSV-fil                        |
|   SaveToFile        = Sparar garage-data till garage.csv                    |
|   LoadFromFile      = Läser in sparade fordon från CSV-fil                  |
|   Autosave          = Sparar automatiskt vid add/remove                     |
|   CSV-format        = Semikolon-separerad fordonsdata                       |
|   Data/garage.csv   = Persistent lagring av garage-data                     |

===========================================================


¤ Unit Testing:


|   App.Tests         = Separat xUnit testprojekt                             |
|   xUnit             = Ramverk för enhetstester                              |
|   AddVehicle tests  = Testar add/logik + duplicate regnr                    |
|   Assertions        = Assert.True / Assert.False                            |

===========================================================

cmd:
dotnet run

===========================================================

