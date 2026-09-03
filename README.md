# Collaborative Medical Augmented Reality Application

A Unity3D + Vuforia AR application that lets a professor ("Master Client") and multiple students ("User Clients") collaboratively view, manipulate, and annotate 3D anatomy models in real time — built to ease remote learning and over-crowded medical classrooms.

## Authors

- Fatih Demirkan
- Hafiz Zee Waqar Irtaza
- Sikandar Ali
 
This project was done in the AR/VR Seminar, Winter Semester 2019–2020, at Universität des Saarlandes.

## Overview

Teaching human anatomy in large or remote classes makes it hard for every student to interact with 3D models directly, and puts extra strain on professors. This project uses augmented reality with real-time collaborative manipulation to solve that: a designated image/leaflet marker is scanned by every participant's device, and a shared 3D organ model (currently a brain) is augmented on top of it. All users see the same object and can interact with it live over the network.

## Key Features

- **Two user roles**
  - **Master Client (Professor):** creates a class, manipulates the shared model without restriction, and whatever they do is visible to the entire class.
  - **User Client (Student):** joins an existing class from a lobby of available classes.
- **Master View vs. Local View:** students can freely rotate/zoom/annotate a private *Local View* copy of the model without affecting what the rest of the class sees, while still being able to watch the professor's *Master View*.
- **Marker-based AR:** Vuforia image tracking detects a designated leaflet/marker and augments the 3D organ model on top of it.
- **Real-time collaboration:** Photon Networking Engine synchronizes object manipulations (rotate, zoom, cut-open) across all connected clients with minimal lag.
- **Toolbar-driven interaction:** actions (add bookmark, cut-open, rotate, zoom) are only active once explicitly toggled from the toolbar, avoiding ambiguous gesture conflicts between pinch-zoom and multi-finger rotation.
- **Bookmarks:** both Master and User clients can tap to leave short notes (questions, definitions, etc.) on the model for later reference. Bookmarks added in Master View are visible to the whole class; bookmarks added in a student's Local View are private to them.
- **Class info panel:** shows the number of current users in a class and info about the class creator on tap.
- **Multi-touch gestures:** multi-finger pinch (zoom), two-finger swipe (rotate), and tap (bookmark) — all gated behind toolbar activation for a clean, unambiguous UX.

## Tech Stack

| Component | Purpose |
|---|---|
| **Unity 3D** | Core engine for 2D/3D app and AR development |
| **Vuforia AR Camera** | Image marker tracking and AR augmentation |
| **Photon Networking Engine** | Multi-user sync of 3D object manipulation over the network |
| **Lean Touch** | Single- and multi-finger touch input (zoom, rotate, tap) |
| **3D Assets** | Brain model used for the demo |

## How It Works

1. Both Master and User clients log in to the Photon server.
2. The Master Client creates a class (e.g. "Anatomy"), which is listed for all connected User Clients to join from the lobby.
3. All participants scan the shared image marker; the 3D organ model is augmented on top of it for everyone.
4. The Master Client manipulates the model freely — visible to the whole class.
5. User Clients switch to their own Local View to freely rotate/zoom/annotate the model without disrupting the shared Master View, while still being able to see the Master View alongside it.
6. Toolbar buttons (add-bookmark, cut-open, rotate, zoom) gate each interaction mode to avoid gesture conflicts.

## Evaluation

Tested internally and with 5 concurrent users (1 Master Client as teacher, 4 User Clients as students). Feedback highlighted:
- Enjoyable, easy to learn, creative, and clear UX.
- Students initially expected a pure mirroring app, but appreciated the added freedom of the Local View once they understood it.
- Minor, largely unnoticeable lag attributed to network conditions and the latency of the free tier of Photon's networking servers.
- Suggested improvement: lag compensation.

The Master Client was able to add the brain object by scanning the marker easily, and all 4 User Clients received real-time updates with only slight, largely unnoticeable lag.

## Limitations

- Minimum supported version: **Android 6.0**; best performance on **Android 7.0+ (API Level 24+)**, which covered ~57.9% of Android devices at the time of testing.
- Requires a stable internet connection for best performance and network communication.

## Future Work

- Local data persistence with the ability to sync/share over the network after reconnecting from a disconnection.
- Migrate to a premium Photon Networking Server tier to reduce latency.

## Conclusion

The team successfully built an interactive, collaborative AR anatomy app tailored for both remote and over-crowded in-person classes, with distinct but connected Master/Local views. Test users responded positively to its usability, including relevance to pandemic-era (COVID-19) remote-learning needs.
