# Mouse.Hook.API

The Mouse.Hook.Api allows you to create a hook in the windows environment via User32.dll imports. Once the hook is made the MouseHook class has 3 events that can be raised. 



#### Methods

Before using the Mouse.Hook.Api we first have to make the hook. Then we can use the events. When we are done using API the hook should be unhooked. Otherwise, allocated resources will not be released.

| Method name      | Description                                                  |
| ---------------- | ------------------------------------------------------------ |
| `MouseHook();`   | When this method is called. Then a hook is made to windows environment. |
| `MouseUnHook();` | When this method is called. Then the hook is unhooked and discarded. |



#### Events

You can listen to events from the MouseHook class when a hook is created.

| Event name       | Description                             |
| ---------------- | :-------------------------------------- |
| `MouseMoveEvent` | Raised when the mouse moves.            |
| `MouseDownEvent` | Raised when a mouse button is clicked.  |
| `MouseUpEvent`   | Raised when a mouse button is released. |



#### MouseEventArgs

Each raised event gives a MouseEventArgs to the listeners.

| Properties | Description                                                  |
| ---------- | ------------------------------------------------------------ |
| `Button`   | Gets which mouse button was pressed.                         |
| `Clicks`   | Gets the number of times the mouse button was pressed and released. |
| `Delta`    | Gets a signed count of the number of detents the mouse wheel has rotated, multiplied by the WHEEL_DELTA constant. A detent is one notch of the mouse wheel. |
| `Location` | Gets the location of the mouse during the generating mouse event. |
| `X`        | Gets the x-coordinate of the mouse during the generating mouse event. |
| `Y`        | Gets the y-coordinate of the mouse during the generating mouse event. |



#### MouseButtons Enum

Enum is used in the Button property of MouseEventArgs.

| Field      | Value    | Description                                                  |
| ---------- | -------- | ------------------------------------------------------------ |
| `Left`     | 1048576  | The left mouse button was pressed.                           |
| `Middle`   | 4194304  | The middle mouse button was pressed.                         |
| `None`     | 0        | No mouse button was pressed.                                 |
| `Right`    | 2097152  | The right mouse button was pressed.                          |
| `XButton1` | 8388608  | The first XButton (XBUTTON1) on Microsoft IntelliMouse Explorer was pressed. |
| `XButton2` | 16777216 | The second XButton (XBUTTON2) on Microsoft IntelliMouse Explorer was pressed |

