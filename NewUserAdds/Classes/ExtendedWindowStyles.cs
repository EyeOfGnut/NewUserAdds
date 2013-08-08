using System;

namespace NewUserAdds.Classes
{
    // Ripped off from http://msdn.microsoft.com/en-us/library/windows/desktop/ff700543%28v=vs.85%29.aspx

    /// <summary>
    /// Static class holding all the extended window styles, for reference or future use.
    /// </summary>
    public static class ExtendedWindowStyles
    {
        public static readonly Int32
            
#pragma warning disable 1591 // Tell the XML comment warnings to STFU

         WS_EX_ACCEPTFILES = 0x00000010, // Allow Drag & Drop of files

         WS_EX_APPWINDOW = 0x00040000, // Forces a top-level window onto the Taskbar when the window is visible

         WS_EX_CLIENTEDGE = 0x00000200,  // The window has a border with a sunken edge

         WS_EX_COMPOSITED = 0x02000000, // Paints window descendants in bottom-to-top order using double-buffering

         WS_EX_CONTEXTHELP = 0x00000400, // The title of the window indludes a question mark, which causes the cursor to change to question mark, for help on specific controls

         WS_EX_CONTROLPARENT = 0x00010000, // Include child windows in Keyboard navigation operations (tab, arrow, etc)

         WS_EX_DLGMODALFRAME = 0x00000001, // Double-border

         WS_EX_LAYERED = 0x00080000, // Layered window

         WS_EX_LAYOUTRTL = 0x00400000, // Shell language is rt-to-left, like Arabic. 

         WS_EX_LEFT = 0x00000000, // *default* Generic Left-Aligned properties

         WS_EX_LEFTSCROLLBAR = 0x00004000, // Scrollbar is to the left if the shell language is a rt-to-left language

         WS_EX_LTRREADING = 0x00000000, // *default* left-to-rt reading order properties

         WS_EX_MDICHILD = 0x00000040, // MDI child window

         WS_EX_NOACTIVATE = 0x08000000, // Don't bring the window to the foreground. 

         WS_EX_NOINHERITLAYOUT = 0x00100000, // Don't pass layout properties to window children

         WS_EX_NOPARENTNOTIFY = 0x00000004, // Don't notify the parent window on creation or destruction
         
         WS_EX_NOREDIRECTIONBITMAP = 0x00200000, // Window doesn't render a visible surface, or renders itself some other way

         WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE, // Overlapped window

         WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST, // Pallette window

         WS_EX_RIGHT = 0x00001000, // Generic right-aligned properties

         WS_EX_RIGHTSCROLLBAR = 0x00000000, // *Default* Scroll bar to the right

         WS_EX_RTLREADING = 0x00002000, // Show text rt-to-left aligned, as in Arabic or Hebrew

         WS_EX_STATICEDGE = 0x00020000, // 3D border style for windows that don't take user input

         WS_EX_TOOLWINDOW = 0x00000080, // Floating toolbar window

         WS_EX_TOPMOST = 0x00000008, // Placed above all other widows, and stay there

         WS_EX_TRANSPARENT = 0x00000020, // Don't paint this window until siblings have been painted. Needed for transparency, but not the ONLY thing needed.

         WS_EX_WINDOWEDGE = 0x00000100; // Rasied window edge.

#pragma warning restore 1591
    }
}
