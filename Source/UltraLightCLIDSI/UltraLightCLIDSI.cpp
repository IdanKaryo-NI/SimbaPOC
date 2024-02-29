//===========================================================================================================================
///  @file UltraLightCLIDSI.cpp
///
///  Implementation of the CLIDSI::LoadDriver().
///
///  Copyright (C) 2011-2023 Simba Technologies Incorporated.
//===========================================================================================================================

#include "CLIDSI.h"
#include "SimbaSettingReader.h"

//===========================================================================================================================
/// @brief Creates an instance of IDriver for a driver. 
///
/// @return IDriver instance. (OWN)
//===========================================================================================================================
Simba::DotNetDSI::IDriver^ Simba::CLIDSI::LoadDriver()
{
    // Set the driver branding.	
    SimbaSettingReader::SetConfigurationBranding("Simba\\DotNetUltraLight");

#ifdef SERVERTARGET
    // Notify the utilities that this is a server.
    Simba::DotNetDSI::Utilities::SetIsServer();
#endif

    // ODBC Driver TODO #1: Construct driver singleton.
    return gcnew OPlusDriver::ULDriver();
}
