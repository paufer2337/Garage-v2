=== C# Övning 3 - Garage Console App - 2.0 ===
___________________________________________________________


¤ Hur är programmets struktur uppbyggd?

 - Program.cs        (Entrypoint + startar appen)
 - Garage.cs         (Garage-logik + hantering av vehicle-array)
 - Vehicle.cs        (Abstrakt basklass för alla fordon)
 - Helpers.cs        (Validering + hjälpmetoder)
 - GarageApp.cs      (App-flow + navigation + menyer)
 - ConsoleUI.cs      (Presentation + output)
 - GarageHandler.cs  (Bridge mellan UI och Garage)
 - VehicleFactory.cs (Vehicle creation + validation flow)
 - GarageFactory.cs  (Garage creation)
 - FileHandler.cs    (JSON persistence)

===========================================================


¤ Vilka klasser innehåller programmet?


~ Basklass:
|   Vehicle         = Gemensam basklass för alla fordon                       |

~ Core:
|   Garage<T>       = Generisk garage-collection                              |
|   GarageHandler   = Business logic + LINQ filtering

~ UI:
|   GarageApp       = App-flow + navigation                                   |
|   ConsoleUI       = Console-presentation + output                           |                         

~ Interfaces:
|   IVehicle        = Kontrakt för alla fordon                                |
|   IHandler        = Kontrakt för GarageHandler                              |                     

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
|   AddVehicle          = Skapar + lägger till nytt fordon                    |
|   RemoveVehicle       = Tar bort fordon via registreringsnummer             |
|   SearchByRegNr       = Söker efter fordon via registreringsnummer          |
|   SearchByProperties  = Meny för sökning via egenskaper                     |

~ GarageApp.cs:
|   Run                  = Startar app-flow                                   |
|   ShowStartMenu        = Startmeny                                          |
|   ShowMainMenu         = Huvudmeny                                          |
|   CreateGarage         = Skapar nytt garage                                 |
|   AddVehicle           = Skapar + parkerar fordon                           |
|   RemoveVehicle        = Tar bort fordon                                    |
|   SearchByRegNr        = Söker via registreringsnummer                      |
|   SearchByProperties   = Property-search meny                               |
|   CombinedSearch       = Kombinerad sökning                                 |
|   ShowSearchResult     = Visar sökresultat                                  |
|   ShowParkedVehicles   = Skriver ut parkerade fordon                        |
|   ListVehicleTypes     = Visar antal fordon per typ                         |
|   SaveGarage           = Sparar garage                                      |
|   LoadGarage           = Laddar garage                                      |
|   Exit                 = Avslutar programmet                                |
|   OnExit               = Hanterar Ctrl+C                                    |

~ Garage.cs:
|   AddVehicle          = Parkerar fordon i första lediga plats               |
|   RemoveVehicle       = Tar bort fordon från array                          |
|   ParkedVehicles      = Skriver ut alla parkerade fordon                    |
|   VehiclesByType      = Räknar antal fordon per typ                         |
|   SearchByRegNr       = Söker efter matchande registreringsnummer           |
|   SearchByProperty    = Söker via vald property                             |
|   GetVehicles         = Returnerar parkerade fordon                         |
|   RegNrExists         = Duplicate-check                                     |
|   IsFull              = Kontrollerar kapacitet                              |
|   Count               = Räknar parkerade fordon                             |
|   GetEnumerator       = Möjliggör foreach                                   |

~ Vehicle.cs:
|   GetInfo             = Returnerar grundläggande fordonsinfo                |
|   GetExtraInfo        = Returnerar subclass-specifik property               |
|   Vehicle()           = Baskonstruktor + validering                         |
|   RegNumber           = Regex-validering + normalisering                    |
|   Color               = Fördefinierad color-validation                      |
|   WheelAmount         = Wheel validation                                    |

~ Helpers.cs:
|   GetOnlyText         = Tillåter endast bokstäver                           |
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


¤ Arkitektur / Struktur:


|   Separation of Concerns = UI / AppFlow / BusinessLogic / Storage           |
|   Generics               = Garage<T>                                        |
|   IEnumerable<T>         = Möjliggör foreach                                |
|   Interfaces             = IHandler + IVehicle                              |
|   LINQ                   = Filtering + search                               |

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
|   Mixed Garage        = Kan hantera alla vehicle-typer                      |
|   Mock Garages        = Förifyllda demo/mock-garage                         |                      
|   Combined search     = Flera filter samtidigt                              |
|   Garage validation   = Förhindrar inkompatibla garage vid load             |
|   Ctrl+C handling     = Säker avslutning                                    |
|   LINQ filtering      = Dynamisk property-search                            |

===========================================================


¤ Filhantering / Persistence:


|   FileHandler.cs     = Hanterar save/load via JSON                          |
|   SaveToFile         = Sparar garage-data till garage.json                  |
|   LoadFromFile       = Läser in sparade fordon från JSON-fil                |
|   DTO-conversion     = Vehicle <-> VehicleData                              |
|   JSON Serialization = System.Text.Json                                     |
|   Data/garage.json   = Persistent lagring av garage-data                    |
|   Capacity-check     = Förhindrar overflow vid load                         |
|   Compatibility      = Validerar garage-typer vid load                      |
|   Overwrite-warning  = Skyddar aktivt garage vid load                       |

===========================================================

¤ Starta Console App:

cmd:
dotnet run


===========================================================


¤ Frontend / Visual Garage Demo:

|   frontend/flexbox-garage.html = Visualiserar garage med Flexbox            |
|   frontend/flex-garage.css     = Styling för Flexbox-layouten               |
|   frontend/grid-garage.html    = Visualiserar garage med CSS Grid           |
|   frontend/garage-grid.css     = Styling för Grid-layouten                  |

Frontend-delen är en separat visuell demo inspirerad av Garage-v2 och skapades 
i samband med de två första frontend-övningarna och använder projektets 
garage-tema för att öva Flexbox och CSS Grid.
Den är inte kopplad till Console Appens runtime.

Flexbox-delen visar fordon som responsiva parkeringscards.
Grid-delen visar ett parkeringsgarage med tre rader, tre kolumner
och en körbana i mitten.

===========================================================

Öppna/Se frontend övningarna:

1. Öppna projektmappen Garage-v2
2. Gå in i frontend mappen
3. Dubbelklicka direkt på HTML-filerna i File Explorer

===========================================================

¤ Frontend-koncept som används:

|   HTML5           = Struktur för webbsidorna                                |
|   CSS3            = Styling och layout                                      |
|   Flexbox         = Responsiv radbrytning av parkeringskort                 |
|   flex-wrap       = Gör att fordonen flyttas till ny rad vid behov          |
|   CSS Grid        = Tvådimensionell garage-layout                           |
|   grid-column     = Placerar parkeringsrutor i specifika kolumner           |
|   grid-row        = Placerar parkeringsrutor i specifika rader              |
|   span            = Används för att låta element sträcka sig över flera rader|

===========================================================

